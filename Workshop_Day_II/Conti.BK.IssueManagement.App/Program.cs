// See https://aka.ms/new-console-template for more information
using Conti.BK.IssueManagement.Impl.Entities;
using Conti.BK.IssueManagement.Impl;
Console.WriteLine("Hello, World!");
var context = new IssuesContext();


var usrContr = new UserController(context);
var issueContr = new IssueController(context);
//usrContr.CreateUser("user002","Peter","Auch-Lustig");
Console.WriteLine(issueContr.GetUsersWithNoIssues().FirstOrDefault().Username);
//var issue = issueContr.CreateIssue("Pizza essen");
//issueContr.AddUserToIssue(issue,issueContr.GetUsersWithNoIssues().FirstOrDefault());
//Console.WriteLine(issueContr.GetUsersWithNoIssues().FirstOrDefault().Username);
issueContr.GetUsersWithMoreThenXIssues(0).ForEach(x=> Console.WriteLine(x.Username));