namespace ticketModels;
using customExceptions;
using System.ComponentModel.DataAnnotations;

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

    public Ticket(string reason, int ID, int authorID, int resolverID, decimal amount) //this is just a place holder constructor to do some basic testing, to be deleted once everything is implemented
    {
        if(!string.IsNullOrEmpty(reason))
        {
            this.reason=reason;
            this.ID=ID;
            this.authorID=authorID;
            this.resolverID=resolverID;
            this.amount=amount;
        }
        else
        {
            throw new ResourceNotFoundException("Please briefly explain the reason for the request");
        }
    }
    public Status status = Status.Pending; //this can go into the constructor, but here is also fine
    public string reason; //is gets assigned when the constructor is called
    public int ID{get;set;} //place holder until further details are known
    public int authorID{get;set;}
    public int resolverID{get;set;}
    public decimal amount{get;set;}

    public override string ToString() // just print stuff out for convenience 
    {
        return "ID: " + this.ID + ", AuthorID: " + this.authorID + ", ResolverID: " + this.resolverID + ", Reason: " + this.reason + ", Status: " + this.status;
    }

}