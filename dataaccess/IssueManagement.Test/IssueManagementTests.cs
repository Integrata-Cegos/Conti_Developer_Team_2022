using IssueManagement.Impl.Entities;
using IssueManagement.Impl;
namespace IssueManagement.Test;

public class Tests
{
    IIssueManagement issueManagement = new IssuenManagementImpl();
    [Test]
    public void TestAddUser()
    {
        var user = issueManagement.CreateUser("rus" + Guid.NewGuid().ToString(), "Sawitzki", "Rainer");
        Assert.That(user.Id > 0);
    }
    [Test]
    public void TestAddIssue()
    {
        var issue = issueManagement.CreateIssue("Important Issue");
        Assert.That(issue.Id > 0);
    }
    [Test]
    public void StatusOpen()
    {
        List<Issue> issues= issueManagement.FindByStatus(Status.OPEN);
        Assert.That(issues.Count > 0);
    }
    [Test]
    public void StatusFinished()
    {
        List<Issue> issues= issueManagement.FindByStatus(Status.FINISHED);
        Assert.That(issues.Count > 0);
    }
    [Test]
    public void PriorityMedium()
    {
        List<Issue> issues= issueManagement.FindByPriority(Priority.MEDIUM);
        Assert.That(issues.Count > 0);
    }
    [Test]
    public void UsersWithoutIssues()
    {
        List<User> users= issueManagement.FindUsersWithoutIssues();
        Assert.That(users.Count > 0);
    }
    [Test]
    public void StressedUsers()
    {
        List<User> users= issueManagement.FindStressedUsers();
        Assert.That(users.Count > 0);
    }
   [Test]
    public void TestAssignenment()
    {

        Assert.DoesNotThrow(() => issueManagement.Assign(1, 2));
    }
   [Test]
    public void TestUpdatePriority()
    {

        Assert.DoesNotThrow(() => issueManagement.UpdatePriority(1, Priority.CRITICAL));
    }
   [Test]
    public void TestUpdateStatusOk()
    {

        Assert.DoesNotThrow(() => issueManagement.UpdateStatus(1, Status.IN_PROGRESS));
    }
   [Test]
    public void TestUpdateStatusFails()
    {

        Assert.That(() => issueManagement.UpdateStatus(5, Status.IN_PROGRESS), Throws.Exception);
    }


}