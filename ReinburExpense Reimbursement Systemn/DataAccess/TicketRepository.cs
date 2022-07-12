namespace TickeData;
using ticketModels;
using ConnectionFactory;
using System.Data.SqlClient;
using customExceptions; 

public class TicketRepository
{
    private int TicketID;
    private string TicketReason;
    private int TicketAuthor;
    private int TicketResolver;
    private Status TicketStatus;
    private string StringStatus;
    private Decimal TicketAmount;

    public Ticket GetReimbursementByID(int ID) //takes a ticket ID and return a Ticket item or exception
    {
        Ticket ReturnTicket = new Ticket("Default Reason");
        return ReturnTicket;
    }

    public List<Ticket> GetReimbursementByStatus(Status ID) //takes a status and returns a list of Tickets with that Status
    {
        List<Ticket> TicketList = new List<Ticket>();
        return TicketList;
    }

    public List<Ticket> GetReimbursementByAuthor(int ID) //takes an author ID and returns a list of Tickets from that author
    {
        List<Ticket> TicketList = new List<Ticket>();
        return TicketList;
    }

    public bool CreateReimbursement(Ticket NewTicket) //takes an ticket item and returns true for successful creation
    {
        SqlConnection connection = ConnectionFactory.GetInstance().GetConnection(); //get a hold of the server
        string sql = "insert into ERS_P1.tickets (reason,status,authorID,resolverID,amount) values (@TicketReason,@StringStatus,@TicketAuthor,@TicketResolver,@TicketAmount);";
        SqlCommand command = new SqlCommand (sql, connection);

        TicketID = NewTicket.ID; //convert everything down to a single variable, there are better way to do this
        TicketReason = NewTicket.reason;
        TicketAuthor = NewTicket.authorID;
        TicketResolver = NewTicket.resolverID;
        TicketStatus = NewTicket.status;
        TicketAmount = NewTicket.amount;
        if(TicketStatus == Status.Approved)
        {
            StringStatus = "Approved";
        }
        else if(TicketStatus == Status.Denied)
        {
            StringStatus = "Denied";
        }
        else
        {
            StringStatus = "Approved";
        }
        
        command.Parameters.AddWithValue("@TicketReason",TicketReason); //adding all the value to the parameters
        command.Parameters.AddWithValue("@StringStatus",StringStatus); //this is a mess
        command.Parameters.AddWithValue("@TicketAuthor",TicketAuthor); //there has to be a better way to do this
        command.Parameters.AddWithValue("@TicketResolver",TicketResolver);
        command.Parameters.AddWithValue("@TicketAmount",TicketAmount);

        try
        {
            //opening the connection to the database
            connection.Open();

            //for DML statements
            int rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            if(rowsAffected==0)
            {
                return false;
            }
                return true;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public bool UpdateReimbursement(Ticket Ticket2Update) //this one is a little complicated, I will updated the logic as I write it
    {
        return false;
    }
}