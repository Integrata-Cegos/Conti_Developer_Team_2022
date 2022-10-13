namespace IssueManagement;

public interface IIssueManager
{
    List<Issue> AllIssuesWithStatus(string status);
    void AssignIssueToUser(Issue issue, User user = null);
    void ChangeIssueStatus(Issue issue, string status);
    Issue CreateIssue(string description);
    User CreateUser(string userName, string firstName, string lastName);
    List<User> SelectOverloadedUsers();
    List<User> SelectUsersWithoutIssues();
}