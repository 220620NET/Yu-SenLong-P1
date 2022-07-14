namespace AuthServices;
using userModels;
using UserData;
using customExceptions;
public static class AuthServices
{
    public static UserRepository UserRepo = new UserRepository(); //I can do this via dependency injection but this is fine for now
    public static User login(User User2LogIn) //Takes a user and return the same user? if the credentials match
    {
        User returnUser = new User();
        try
        {
            returnUser = UserRepo.GetUser(User2LogIn.userName); //grab the record with the same username
        }
        catch (RecordNotFoundException) //such record cannot be found, throw an exception 
        {
            throw new InvalidCredentialsException("Please double check your login information and try again");
        }

        if (returnUser.passWord == User2LogIn.passWord) //the record with the same username is found, check for password
        {
            return returnUser;
        }
        throw new InvalidCredentialsException("Please double check your login information and try again"); //password is wrong
    }

    public static int Register(User User2Regi) //Takes a user and return the same user if the registration is successful
    {
        try
        {
            User returnUser = UserRepo.GetUser(User2Regi.userName); //grab the record with the same username
        }
        catch (RecordNotFoundException) //such record cannot be found, start the registration process 
        {
            int ID2Return = UserRepo.CreateUser(User2Regi);
            if(ID2Return>0) //greater than zero means you are probably good
            {
                return ID2Return;
            }
            throw new ResourceNotFoundException("Account Register Failed, Please Try Again or Ask For Help From You Data Technician");
        }
        throw new UsernameNotAvailableException("UserName Already In Use");
    }
}
