namespace ConnectionFactory;
using System.Data.SqlClient;
using sensitive;

public class ConnectionFactory
{
    //Hidding the password in another file for now, can change later
    private readonly string _connectionString = "Server=tcp:syuserver.database.windows.net,1433;Initial Catalog=SenLong's DataBase;Persist Security Info=False;User ID=sqluser;Password="+ sensitiveVariables.dbpassword+";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    private static ConnectionFactory? _instance;

    private ConnectionFactory()
    {
    }
    public static ConnectionFactory GetInstance() //make sure that there exist only one Connections Factory Object
    {
        if(_instance == null)
        {
            _instance = new ConnectionFactory();
        }
            return _instance;
    }

    public SqlConnection GetConnection() //returns just the connection to the server
    {
        SqlConnection connection = new SqlConnection(_connectionString); //I think you can do this is a cute one liner, but I forgot how to
        return connection;
    }
}