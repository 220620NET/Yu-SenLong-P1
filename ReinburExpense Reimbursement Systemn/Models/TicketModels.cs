namespace ticketModels;
using customExceptions;

public enum Status //since there are only three possible status, enum helps in tracking them
{
    Pending,
    Approved,
    Denied
}

public class Ticket
{
    public Ticket(string reason)
    {
        if(!string.IsNullOrEmpty(reason))
        {
            this.reason=reason;
        }
        else
        {
            throw new ResourceNotFoundException("Please briefly explain the reason for the request");
        }
    }

    public Ticket(string reason, long ID, long authorID, long resolverID) //this is just a place holder constructor to do some basic testing, to be deleted once everything is implemented
    {
        if(!string.IsNullOrEmpty(reason))
        {
            this.reason=reason;
            this.ID=ID;
            this.authorID=authorID;
            this.resolverID=resolverID;
        }
        else
        {
            throw new ResourceNotFoundException("Please briefly explain the reason for the request");
        }
    }
    public Status status = Status.Pending; //this can go into the constructor, but here is also fine
    public string reason; //is gets assigned when the constructor is called
    public long ID{get;set;} //place holder until further details are known
    public long authorID{get;set;}
    public long resolverID{get;set;}
    private decimal amount;

}