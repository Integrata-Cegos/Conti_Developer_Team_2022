using Conti.BK.IssueManagement.Impl.Entities;
using Conti.BK.IssueManagement.Impl;
public class IssueController{
    private IssuesContext _context;
    public IssueController(IssuesContext context){
        this._context = context;
    }

    public BkIssue CreateIssue(string description){
        var issue = new BkIssue(){Description=description,Status=(byte?)Status.open,Priority=(byte?)Priority.MEDIUM};
        _context.BkIssues.Add(issue);
        _context.SaveChanges();
        return issue;
    }
    public bool AddUserToIssue(BkIssue issue, BkUser user){
        issue.Assignee = user.Id;
        user.BkIssues.Add(issue);
        _context.SaveChanges();
        return true;
    }
    public void SetStatus(BkIssue issue, Status status){
        issue.Status = (byte?)status;
        _context.SaveChanges();
    }
    public void SetPrio(BkIssue issue, Priority prio){
        issue.Priority = (byte?)prio;
        _context.SaveChanges();
    }
    public List<BkIssue> GetIssuesWithStatus(Status status){
        return _context.BkIssues.Where(x=> x.Status == (byte?)status).ToList();
    }
    public List<BkUser> GetUsersWithNoIssues(){
        return _context.BkUsers.Where(x=>x.BkIssues.Count() == 0).ToList();
    }
    public List<BkUser> GetUsersWithMoreThenXIssues(int count){
        return _context.BkUsers.Where(x=>x.BkIssues.Count() > count).ToList();
    }
}