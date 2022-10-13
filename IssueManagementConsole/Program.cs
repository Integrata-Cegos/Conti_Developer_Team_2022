using IssueManagement;

IssueManager IM = new();

//IM.CreateIssue("Hallo");
//IM.CreateUser($"Test {Guid.NewGuid()}", "FirstName", "LastName");
//var issues = IM.AllIssuesWithStatus("CRITICAL");
//var freeusers = IM.SelectUsersWithoutIssues();
//IM.AssignIssueToUser(IM.AllIssuesWithStatus("OPEN").First(), freeusers.First());
//IM.AssignIssueToUser(IM.AllIssuesWithStatus("OPEN").First());
//freeusers = IM.SelectUsersWithoutIssues();
var issues = IM.AllIssuesWithStatus("OPEN");
IM.ChangeIssuePriority(issues.Last(), "LOW");
var history = IM.ShowHistoryForIssue(issues.Where(x => x.Id == 103).First());
//var overloadedusers = IM.SelectOverloadedUsers();
Console.ReadKey();