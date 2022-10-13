using IssueManagement;

IssueManager IM = new();

//IM.CreateIssue("Hallo");
//IM.CreateUser("Thomas", "Test", "Bla");
//var issues = IM.AllIssuesWithStatus("OPEN");
//var freeusers = IM.SelectUsersWithoutIssues();
//IM.AssignIssueToUser(IM.AllIssuesWithStatus("OPEN").First(), freeusers.First());
//IM.AssignIssueToUser(IM.AllIssuesWithStatus("OPEN").First());
//freeusers = IM.SelectUsersWithoutIssues();

var overloadedusers = IM.SelectOverloadedUsers();
Console.ReadKey();