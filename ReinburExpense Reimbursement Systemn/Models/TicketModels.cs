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

    public Ticket()
    {
        this.reason="Default Reason, contact your data manager to get this fixed";
    }

    public Ticket(string reason, int ID, int authorID, int resolverID, decimal amount) //this is just a place holder constructor to do some basic testing, to be deleted once everything is implemented
    {
        if(!string.IsNullOrEmpty(reason))
        {
            this.reason=reason;
            this.ID=ID;
            this.authorID=authorID;
            this.resolverID=resolverID;
            this.amount=amount;
            this.status = Status.Pending;
        }
        else
        {
            throw new ResourceNotFoundException("Please briefly explain the reason for the request");
        }
    }

    public Ticket(string reason, int ID, int authorID, int resolverID, decimal amount, Status status) //this is just a place holder constructor to do some basic testing, to be deleted once everything is implemented
    {
        if(!string.IsNullOrEmpty(reason))
        {
            this.reason=reason;
            this.ID=ID;
            this.authorID=authorID;
            this.resolverID=resolverID;
            this.amount=amount;
            this.status = status;
        }
        else
        {
            throw new ResourceNotFoundException("Please briefly explain the reason for the request");
        }
    }

    public Status status;
    public string reason; //is gets assigned when the constructor is called
    public int ID{get;set;} //place holder until further details are known
    public int authorID{get;set;}
    public int resolverID{get;set;}
    public decimal amount{get;set;}

    public override string ToString() // just print stuff out for convenience 
    {
        return "ID: " + this.ID + ", AuthorID: " + this.authorID + ", ResolverID: " + this.resolverID + ", Reason: " + this.reason + ", Status: " + this.status +", Amount:" +this.amount;
    }

}