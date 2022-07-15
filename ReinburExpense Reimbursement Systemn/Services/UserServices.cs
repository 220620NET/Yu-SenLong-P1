namespace UserServices;
using UserData;

public class UserServices
{//for detailed documentation on each method, see UserRepo class
    private readonly UserRepository _UserRepo;
    public UserServices(UserRepository UserRepo)
    {
        _UserRepo = UserRepo;
    }

    public List<User> GetAllUsers()
    {
        try
        {
            return _UserRepo.GetAllUsers();
        }
        catch(exception)
        {
            throw;
        }
    }

    public int CreateUser(User NewUser)
    {
        if(!String.IsNullOrWhiteSpace(NewUser.userName) && !String.IsNullOrEmpty(NewUser.userName))
        {
            try
            {
                return _UserRepo.CreateUser(NewUser);
            }
            catch(exception)
            {
                throw;
            }
        }
        throw new ResourceNotFoundException("Please Input A Username");
    }

    public User GetUser(string Name2Get)
    {
        if(!String.IsNullOrWhiteSpace(Name2Get) && !String.IsNullOrEmpty(Name2Get))
        {
            try
            {
                return _UserRepo.GetUser(Name2Get);
            }
            catch(exception)
            {
                throw;
            }
        }
        throw new ResourceNotFoundException("Please Input A Username");
    }

    public User GetUser(int ID2Get)
    {
        if(ID2Get>0)
        {
            try
            {
                return _UserRepo.GetUser(ID2Get);
            }
            catch(exception)
            {
                throw;
            }
        }
        throw new ResourceNotFoundException("Please Input A Valid ID");
    }
}