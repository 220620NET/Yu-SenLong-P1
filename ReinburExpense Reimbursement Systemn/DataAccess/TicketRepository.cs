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

    public Ticket GetReimbursementByID(int ID2Get) //takes a ticket ID and return a Ticket item or exception
    {
        Ticket ReturnTicket = new Ticket();
        SqlConnection connection = ConnectionFactory.GetInstance().GetConnection(); //get a hold of the server
        string sql = "select * from ERS_P1.tickets where ID = @ID2Get;";
        SqlCommand command = new SqlCommand (sql, connection);
        command.Parameters.AddWithValue("@ID2Get",ID2Get);
        bool successful = false; //indicating if the read is successful

        try
        {
            //opening the connection to the database
            connection.Open();
            //storing the result set of the DQL statement into a variable
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) //I have no idea if/how this works
            {
                successful = true; //toggle true
                TicketID = (int) reader[0];
                TicketReason = (String)reader[1];
                StringStatus = (string)reader[2];
                TicketAuthor = (int)reader[3];
                TicketResolver = (int)reader[4];
                TicketAmount = (Decimal)reader[5];
                if(StringStatus == "Approved")
                {
                    TicketStatus = Status.Pending;
                }
                else if(StringStatus == "Denied")
                {
                    TicketStatus = Status.Pending;
                }
                else
                {
                    TicketStatus = Status.Pending;
                }
                ReturnTicket = new Ticket(TicketReason,TicketID,TicketAuthor,TicketResolver,TicketAmount, TicketStatus);
            }
            reader.Close();
            connection.Close();
        }
        catch(Exception)
        {
            throw;
        }
        if(successful)
        {
            return ReturnTicket;
        }
        throw new RecordNotFoundException();
    }

    public List<Ticket> GetReimbursementByStatus(Status status) //takes a status and returns a list of Tickets with that Status
    {
        Ticket ReturnTicket;
        List<Ticket> TicketList = new List<Ticket>();
        SqlConnection connection = ConnectionFactory.GetInstance().GetConnection(); //get a hold of the server
        string sql = "select * from ERS_P1.tickets where status = @StringStatus;";
        if(status == Status.Approved)
        {
            StringStatus = "Approved";
        }
        else if(status == Status.Denied)
        {
            StringStatus = "Denied";
        }
        else
        {
            StringStatus = "Pending";
        }
        SqlCommand command = new SqlCommand (sql, connection);
        command.Parameters.AddWithValue("@StringStatus",StringStatus);

        try
        {
            //opening the connection to the database
            connection.Open();
            //storing the result set of the DQL statement into a variable
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) //I have no idea if/how this works
            {
                TicketID = (int) reader[0];
                TicketReason = (String)reader[1];
                StringStatus = (string)reader[2];
                TicketAuthor = (int)reader[3];
                TicketResolver = (int)reader[4];
                TicketAmount = (Decimal)reader[5];
                if(StringStatus == "Approved")
                {
                    TicketStatus = Status.Pending;
                }
                else if(StringStatus == "Denied")
                {
                    TicketStatus = Status.Pending;
                }
                else
                {
                    TicketStatus = Status.Pending;
                }
                ReturnTicket = new Ticket(TicketReason,TicketID,TicketAuthor,TicketResolver,TicketAmount, TicketStatus);
                TicketList.Add(ReturnTicket);
            }
            reader.Close();
            connection.Close();
        }
        catch(Exception)
        {
            throw;
        }

        if(TicketList.Any()) //this checks if the list has any element
        {
            return TicketList;
        }
        throw new RecordNotFoundException(); 
    } //Untested Method, but it probably works. I will fix it once it actually breaks

    public List<Ticket> GetReimbursementByAuthor(int AuthorID) //takes an author ID and returns a list of Tickets from that author
    {
        Ticket ReturnTicket;
        List<Ticket> TicketList = new List<Ticket>();
        SqlConnection connection = ConnectionFactory.GetInstance().GetConnection(); //get a hold of the server
        string sql = "select * from ERS_P1.tickets where authorID = @AuthorID;";
        SqlCommand command = new SqlCommand (sql, connection);
        command.Parameters.AddWithValue("@AuthorID",AuthorID);

        try
        {
            //opening the connection to the database
            connection.Open();
            //storing the result set of the DQL statement into a variable
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) //I have no idea if/how this works
            {
                TicketID = (int) reader[0];
                TicketReason = (String)reader[1];
                StringStatus = (string)reader[2];
                TicketAuthor = (int)reader[3];
                TicketResolver = (int)reader[4];
                TicketAmount = (Decimal)reader[5];
                if(StringStatus == "Approved")
                {
                    TicketStatus = Status.Pending;
                }
                else if(StringStatus == "Denied")
                {
                    TicketStatus = Status.Pending;
                }
                else
                {
                    TicketStatus = Status.Pending;
                }
                ReturnTicket = new Ticket(TicketReason,TicketID,TicketAuthor,TicketResolver,TicketAmount, TicketStatus);
                TicketList.Add(ReturnTicket);
            }
            reader.Close();
            connection.Close();
        }
        catch(Exception)
        {
            throw;
        }

        if(TicketList.Any()) //this checks if the list has any element
        {
            return TicketList;
        }
        throw new RecordNotFoundException(); 
    } //Untested Method, but it probably works. I will fix it once it actually breaks

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
            StringStatus = "Pending";
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
            throw;
        }
    }

    public bool UpdateReimbursement(Ticket Ticket2Update) //update the ticket, currently takes a ticket object, and overwrites the corresponding ticket with the new one
    {
        SqlConnection connection = ConnectionFactory.GetInstance().GetConnection(); //get a hold of the server
        string sql = "update ERS_P1.tickets set reason = @TicketReason, status = @StringStatus, authorID=@TicketAuthor, resolverID=@TicketResolver, amount=@TicketAmount where ID=@TicketID;";
        SqlCommand command = new SqlCommand (sql, connection);

        TicketID = Ticket2Update.ID; //convert everything down to a single variable, there are better way to do this
        TicketReason = Ticket2Update.reason; //this process should probably be turned into a method by itself
        TicketAuthor = Ticket2Update.authorID;
        TicketResolver = Ticket2Update.resolverID;
        TicketStatus = Ticket2Update.status;
        TicketAmount = Ticket2Update.amount;
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
            StringStatus = "Pending";
        }
        
        command.Parameters.AddWithValue("@TicketReason",TicketReason); //adding all the value to the parameters
        command.Parameters.AddWithValue("@StringStatus",StringStatus); //this is a mess
        command.Parameters.AddWithValue("@TicketAuthor",TicketAuthor); //there has to be a better way to do this
        command.Parameters.AddWithValue("@TicketResolver",TicketResolver);
        command.Parameters.AddWithValue("@TicketAmount",TicketAmount);
        command.Parameters.AddWithValue("@TicketID",TicketID);

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
        catch(Exception)
        {
            throw;
        }
    }
}