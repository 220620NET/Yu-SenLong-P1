namespace UserData;
using userModels;
using ConnectionFactory;
using System.Data.SqlClient;
using customExceptions; 

public class UserRepository
{
    private int UserID;
    private string UserName;
    private string PassWord;
    private Role UserRole;
    private string StringRole;


    public List<User> GetAllUsers()
    {
        List<User> UserList = new List<User>(); //list to be returned 
        SqlConnection connection = ConnectionFactory.GetInstance().GetConnection(); //get a hold of the server
        string sql = "select * from ERS_P1.users;"; //the command to extract all records from a table
        SqlCommand command = new SqlCommand (sql, connection); //turn it into a command object

        try
        {
            //opening the connection to the database
            connection.Open();
            //storing the result set of the DQL statement into a variable
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) //I have no idea if/how this works
            {
                UserID = (int) reader[0];
                UserName = (String)reader[1];
                PassWord = (String)reader[2];
                StringRole = (String)reader[2];
                if(StringRole == "Manager")
                {
                    UserRole = Role.Manager;
                }
                else
                {
                    UserRole = Role.Employee; //this will catch everything else hopefully
                }
                UserList.Add(new User(UserID, UserName, PassWord, UserRole)); //I have no idea if this would work
            }
            reader.Close();
            connection.Close();
        }
        catch(Exception)
        {
            throw;
        }
        return UserList;
    }

    public bool CreateUser(User NewUser)
    {
        SqlConnection connection = ConnectionFactory.GetInstance().GetConnection(); //get a hold of the server
        string sql = "insert into ERS_P1.users (username,password,role) values (@username,@password,@role);";
        SqlCommand command = new SqlCommand (sql, connection);

        UserID = NewUser.ID; //convert everything down to a single variable, there are better way to do this
        UserName = NewUser.userName;
        PassWord = NewUser.passWord;
        UserRole = NewUser.userRole;
        if(UserRole == Role.Manager)
        {
            StringRole = "Manager";
        }
        else
        {
            StringRole = "Employee"; //this will catch everything else hopefully
        }
        
        command.Parameters.AddWithValue("@username",UserName); //adding all the value to the parameters
        command.Parameters.AddWithValue("@password",PassWord);
        command.Parameters.AddWithValue("@role",StringRole);

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

    public User GetUser(string Name2Get) //Username is unique so returning one user is fine
    {
        SqlConnection connection = ConnectionFactory.GetInstance().GetConnection(); //get a hold of the server
        string sql = "select * from ERS_P1.users where username = '@Name2Get';";
        SqlCommand command = new SqlCommand (sql, connection);
        command.Parameters.AddWithValue("@Name2Get",Name2Get);
        User ReturnUser = new User(); //forward declaration, assignment comes in later in the while loop
        bool successful = false; //indicating if the read is successful

        try
        {
            //opening the connection to the database
            connection.Open();
            //storing the result set of the DQL statement into a variable
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read()) //I have no idea if/how this works
            {
                successful = true; //toggle true, there is atleast one thing to read
                UserID = (int) reader[0];
                UserName = (String)reader[1];
                PassWord = (String)reader[2];
                StringRole = (String)reader[2];
                if(StringRole == "Manager")
                {
                    UserRole = Role.Manager;
                }
                else
                {
                    UserRole = Role.Employee; //this will catch everything else hopefully
                }
                ReturnUser = new User(UserID,UserName,PassWord,UserRole);
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
            return ReturnUser;
        }
        throw new RecordNotFoundException();
        
    }

    public User GetUser(int ID2Get) //ID is unique so returning one user is fine
    {
        SqlConnection connection = ConnectionFactory.GetInstance().GetConnection(); //get a hold of the server
        string sql = "select * from ERS_P1.users where ID = @ID2Get;";
        SqlCommand command = new SqlCommand (sql, connection);
        command.Parameters.AddWithValue("@ID2Get",ID2Get);
        User ReturnUser = new User(); //forward declaration, assignment comes in later in the while loop
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
                UserID = (int) reader[0];
                UserName = (String)reader[1];
                PassWord = (String)reader[2];
                StringRole = (String)reader[2];
                if(StringRole == "Manager")
                {
                    UserRole = Role.Manager;
                }
                else
                {
                    UserRole = Role.Employee; //this will catch everything else hopefully
                }
                ReturnUser = new User(UserID,UserName,PassWord,UserRole);
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
            return ReturnUser;
        }
        throw new RecordNotFoundException();
    }
}