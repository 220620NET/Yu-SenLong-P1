namespace TicketServices;
using TickeData;

public class TicketServices
{//for detailed documentation on each method, see TicketRepo class
    private readonly TicketRepository _TicketRepo;
    public TicketServices(TicketRepository TicketRepo)
    {
        _TicketRepo = TicketRepo;
    }

    public public bool UpdateReimbursement(Ticket Ticket2Update)
    {
        try
        {
            return _TicketRepo.UpdateReimbursement(Ticket2Update);
        }
        catch(exception)
        {
            throw;
        }
    }

    public bool CreateReimbursement(Ticket NewTicket)
    {
        try
        {
            return _TicketRepo.CreateReimbursement(NewTicket);
        }
        catch(exception)
        {
            throw;
        }
    }

    public List<Ticket> GetReimbursementByAuthor(int AuthorID)
    {
        try
        {
            return _TicketRepo.GetReimbursementByAuthor(AuthorID);
        }
        catch(exception)
        {
            throw;
        }
    }

    public List<Ticket> GetReimbursementByStatus(Status status)
    {
        try
        {
            return _TicketRepo.GetReimbursementByStatus(status);
        }
        catch(exception)
        {
            throw;
        }
    }

    public Ticket GetReimbursementByID(int ID2Get)
    {
        try
        {
            return _TicketRepo.GetReimbursementByID(ID2Get);
        }
        catch(exception)
        {
            throw;
        }
    }
}