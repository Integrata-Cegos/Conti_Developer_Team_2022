namespace Conti.BK.IssueManagement.Impl;
public enum Status: byte
{
    open = (byte)0,
    inProgress= (byte)1,
    finished= (byte)2
}
public enum Priority: byte
{
    LOW= (byte)1,
    MEDIUM= (byte)2,
    HIGH= (byte)3,
    CRITICAL= (byte)4
}