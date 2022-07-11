namespace ConnectionFactory;
using System.Data.SqlClient;
using sensitive;

public class ConnectionFactory
{
    //Hidding the password in another file for now, can change later
    private static string connectionString = "Server=tcp:syuserver.database.windows.net,1433;Initial Catalog=SenLong's DataBase;Persist Security Info=False;User ID=sqluser;Password="+ sensitiveVariables.dbpassword+";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public static void GetInstance()
    {
        //idk what goes in here, So Imma leave it empty for now
    }

    public static SqlConnection GetConnection() //returns just the connection to the server
    {
        SqlConnection connection = new SqlConnection(connectionString); //I think you can do this is a cute one liner, but I forgot how to
        return connection;
    }
}