namespace Controllers;
using UserService;
using userModels;
using customExceptions;

public class UserController
{
    private readonly UserServices _UServices;

    public UserController(UserServices UserServices)
    {
        _UServices = UserServices;
    }

    public IResult GetAllUsers()
    {
        try
        {
            List<User> UserList = _UServices.GetAllUsers(); //I think this has to happen in another line for the try catch to work
            return Results.Accepted("/users", UserList);
        }
        catch(Exception)
        {
            return Results.Conflict("Something has gone wrong, please try again");
        }
    }

    public IResult GetUser(string Name2Get)
    {
        try
        {
            User ReturnUser = _UServices.GetUser(Name2Get); //I think this has to happen in another line for the try catch to work
            return Results.Accepted("/users", ReturnUser);
        }
        catch(Exception)
        {
            return Results.Conflict("Something has gone wrong, please try again");
        }
    }
    public IResult GetUser(int ID2Get)
    {
        try
        {
            User ReturnUser = _UServices.GetUser(ID2Get); //I think this has to happen in another line for the try catch to work
            return Results.Accepted("/users", ReturnUser);
        }
        catch(Exception)
        {
            return Results.Conflict("Something has gone wrong, please try again");
        }
    }
}