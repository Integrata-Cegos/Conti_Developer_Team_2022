using IssueManagement.Impl.Entities;
namespace IssueManagement.Impl;

public enum Priority
{
    LOW, MEDIUM, HIGH, CRITICAL
}
public enum Status
{
    OPEN, IN_PROGRESS, FINISHED
}
public interface IIssueManagement
{
    public Issue CreateIssue(string description);
    public User CreateUser(string username, string lastame, string firstname);
    public void Assign(int issueId, int userId);

    public void UpdatePriority(int issueId, Priority priority);
    public void UpdateStatus(int issueID, Status status);
    public List<Issue> FindByPriority(Priority priority);

    public List<Issue> FindByStatus(Status status);
    public List<User> FindUsersWithoutIssues();

    public List<User> FindStressedUsers();


}


public class IssuenManagementImpl: IIssueManagement
{

    public Issue CreateIssue(string description)
    {
        var dbContext = new Issues_RefContext();
        var issue = new Issue();
        issue.Description = description;
        issue.Priority = PriorityToByte(Priority.MEDIUM);
        issue.Status = StatusToByte(Status.OPEN);
        dbContext.Issues.Add(issue);
        dbContext.SaveChanges(); 
        return issue;
    }
    public User CreateUser(string username, string lastname, string firstname)
    {
        var dbContext = new Issues_RefContext();
        var user = new User();
        user.Username = username;
        user.Lastname = lastname;
        user.Firstname = firstname;
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
        return user; 
    }
    public void Assign(int issueId, int userId)
    {
        var dbContext = new Issues_RefContext();
        User? user = dbContext.Users.Find(userId);
        Issue? issue = dbContext.Issues.Find(issueId);
        if (user != null && issue != null)
        {
            issue.AssigneeNavigation = user;
            dbContext.SaveChanges();
        }
    }

    public void UpdatePriority(int issueId, Priority priority)
    {
        var dbContext = new Issues_RefContext();
        Issue? issue = dbContext.Issues.Find(issueId);
        if (issue != null)
        {
            issue.Priority = PriorityToByte(priority);
            dbContext.SaveChanges();
        }
    }
    public void UpdateStatus(int issueId, Status status)
    {
        var dbContext = new Issues_RefContext();
        Issue? issue = dbContext.Issues.Find(issueId);
        if (issue != null)
        {
            issue.Status = StatusToByte(status);
            dbContext.SaveChanges();
        }
    }
    public List<Issue> FindByPriority(Priority priority)
    {
        var dbContext = new Issues_RefContext();
        var priorityAsByte = PriorityToByte(priority);
        return dbContext.Issues.Where(Issue => Issue.Priority == priorityAsByte).ToList();
    }

    public List<Issue> FindByStatus(Status status)
    {
        var dbContext = new Issues_RefContext();
        var statusAsByte = StatusToByte(status);
        return dbContext.Issues.Where(Issue => Issue.Status == statusAsByte).ToList();
    }
    public List<User> FindUsersWithoutIssues()
    {
        var dbContext = new Issues_RefContext();
        return dbContext.Users.Where(user => user.Issues.Count == 0).ToList();

    }

    public List<User> FindStressedUsers()
    {
        var dbContext = new Issues_RefContext();
        return dbContext.Users.Where(user => user.Issues.Count > 2).ToList();

    }
    private byte PriorityToByte(Priority priority)
    {
        switch (priority){
            case Priority.LOW:
                return 1;
            case Priority.MEDIUM:
                return 2;
            case Priority.HIGH:
                return 3;
            case Priority.CRITICAL:
                return 4;
        }
        throw new Exception("Illegal priority");
    }
    private byte StatusToByte(Status status)
    {
        switch (status){
            case Status.OPEN:
                return 0;
            case Status.IN_PROGRESS:
                return 1;
            case Status.FINISHED:
                return 2;
        }
        throw new Exception("Illegal status");
    }

}