using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueManagement;
public class IssueManager : IIssueManager
{
    IssueContext db = new IssueContext();

    public Issue CreateIssue(string description)
    {
        if (description == null)
        {
            throw new ArgumentNullException();
        }
        try
        {
            Issue issue = new Issue { Description = description, Priority = "MEDIUM", Status = "OPEN" };
            db.Add(issue);
            db.SaveChanges();
            return issue;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Creating Issue in Database!", ex);
        }
    }

    public User CreateUser(string userName, string firstName, string lastName)
    {
        if (userName == null || firstName == null || lastName == null)
        {
            throw new ArgumentNullException();
        }
        try
        {
            User user = new User { Username = userName, Firstname = firstName, Lastname = lastName };
            db.Add(user);
            db.SaveChanges();
            return user;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Creating User in Database!", ex);
        }
    }

    public void AssignIssueToUser(Issue issue, User user = null)
    {
        if (issue == null)
        {
            throw new ArgumentNullException();
        }
        try
        {
            if (user == null)
            {
                issue.AssigneeNavigation = db.Users.OrderBy(r => EF.Functions.Random()).Take(1).ToList().First();
                issue.Status = "IN PROGRESS";
                db.SaveChanges();
            }
            else
            {
                issue.AssigneeNavigation = user;
                issue.Status = "IN PROGRESS";
                db.SaveChanges();
            }

        }
        catch (Exception ex)
        {
            throw new Exception("Error assigning issue to user in database!", ex);
        }
    }

    public void ChangeIssueStatus(Issue issue, string status)
    {
        if (issue == null || status == null)
        {
            throw new ArgumentNullException();
        }
        try
        {
            issue.Status = status;
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Error changing issue status in database!", ex);
        }
    }

    public List<Issue> AllIssuesWithStatus(string status)
    {
        if (status == null)
        {
            throw new ArgumentNullException();
        }
        return db.Issues.Where(x => x.Status == status).ToList();
    }

    public List<User> SelectUsersWithoutIssues()
    {
        return db.Users.Where(x => !db.Issues.Select(b => b.Assignee).Contains(x.Id)).ToList();
    }

    public List<User> SelectOverloadedUsers()
    {
        var nonemptyissueusers = db.Users.Where(x => db.Issues.Select(b => b.Assignee).Contains(x.Id)).SelectMany(o => o.Issues);
        var groupedusersbyissues = from User in nonemptyissueusers
                                   group User by User.Assignee into usergroup
                                   select new { User = usergroup.Key, Count = usergroup.Count() };
        var userswithissuesgreaterthan2 = groupedusersbyissues.Where(x => x.Count > 2).Select(x => x.User).ToList();
        return db.Users.Where(x => userswithissuesgreaterthan2.Contains(x.Id)).ToList();
    }

}
