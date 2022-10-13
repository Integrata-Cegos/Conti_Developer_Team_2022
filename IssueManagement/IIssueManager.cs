namespace IssueManagement;

public interface IIssueManager
{
    List<Issue> AllIssuesWithStatus(string status);
    void AssignIssueToUser(Issue issue, User user = null);
    Issue ChangeIssueStatus(Issue issue, string status);
    Issue ChangeIssuePriority(Issue issue, string priority);
    Issue CreateIssue(string description);
    User CreateUser(string userName, string firstName, string lastName);
    List<User> SelectOverloadedUsers();
    List<User> SelectUsersWithoutIssues();
    List<History> ShowHistoryForIssue(Issue issue);
}