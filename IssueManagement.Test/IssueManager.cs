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
}