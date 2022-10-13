using Conti.BK.IssueManagement.Impl.Entities;
public class UserController{
    private IssuesContext _context;
    public UserController(IssuesContext context){
        this._context = context;
    }

    public BkUser CreateUser(string username, string firstname, string lastname){
        var user = new BkUser(){Username=username,Firstname=firstname,Lastname=lastname};
        _context.BkUsers.Add(user);
        _context.SaveChanges();
        return user;
    }
    
}