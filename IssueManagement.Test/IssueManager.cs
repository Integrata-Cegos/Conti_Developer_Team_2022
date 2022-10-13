namespace IssueManagement.Test;

public class Tests
{
    IIssueManager _manager = new IssueManager();


    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestUserCreation()
    {
        var user = _manager.CreateUser($"Test {Guid.NewGuid()}", "FirstName", "LastName");
        Assert.That(user.Id > 0);
    }

    [Test]
    public void TestIssueCreation()
    {
        var issue = _manager.CreateIssue($"Test {Guid.NewGuid()}");
        Assert.That(issue.Id > 0);
    }
    [Test]
    public void TestIssueStatusChange()
    {
        var issue = _manager.CreateIssue($"Test {Guid.NewGuid()}");
        _manager.AssignIssueToUser(issue);
        var issueafterassignment = _manager.ChangeIssueStatus(issue, "IN PROGRESS");
        Assert.That(issueafterassignment.Status == "IN PROGRESS");
    }
    [Test]
    public void TestIssueStatusChangeFailedWithoutSettingUser()
    {
        var issue = _manager.CreateIssue($"Test {Guid.NewGuid()}");
        Assert.Throws<Exception>(() => _manager.ChangeIssueStatus(issue, "IN PROGRESS"));
    }
    [Test]
    public void TestAssertIssue()
    {
        var issue = _manager.CreateIssue($"Test {Guid.NewGuid()}");
        _manager.AssignIssueToUser(issue);
        Assert.That(issue.Assignee > 0);
    }
    [Test]
    public void TestChangePriority()
    {
        var issue = _manager.CreateIssue($"Test {Guid.NewGuid()}");
        _manager.ChangeIssuePriority(issue, "CRITICAL");
        Assert.That(issue.Priority == "CRITICAL");
    }
    [Test]
    public void TestGetIssuesByStatus()
    {
        var issue = _manager.CreateIssue($"Test {Guid.NewGuid()}");
        var issue2 = _manager.AllIssuesWithStatus("OPEN");
        Assert.That(issue2.Count > 0);
    }
    [Test]
    public void TestGetUsersWithoutAssignments()
    {
        var user = _manager.CreateUser($"Test {Guid.NewGuid()}", "FirstName", "LastName");
        var freeusers = _manager.SelectUsersWithoutIssues();
        Assert.That(freeusers.Count > 0);
    }
    [Test]
    public void TestGetOverloadedUsers()
    {
        var user = _manager.CreateUser($"Test {Guid.NewGuid()}", "FirstName", "LastName");
        var issue = _manager.CreateIssue($"Test {Guid.NewGuid()}");
        var issue2 = _manager.CreateIssue($"Test {Guid.NewGuid()}");
        var issue3 = _manager.CreateIssue($"Test {Guid.NewGuid()}");
        _manager.AssignIssueToUser(issue, user);
        _manager.AssignIssueToUser(issue2, user);
        _manager.AssignIssueToUser(issue3, user);
        var overloadedusers = _manager.SelectOverloadedUsers();
        Assert.That(overloadedusers.Count > 0);
    }
}