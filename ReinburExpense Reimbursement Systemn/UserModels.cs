namespace userModels;

public enum Role //since there are only two possible roles, enum helps in tracking them
{
    Manager,
    Employee
}
public class User
{
    public User(String ID, String userName, String passWord, Role role) //these are just placeholder attributes that does nothing more than the default getter and setters
    {
        this.ID = ID;
        this.userName = userName;
        this.passWord = passWord;
        this.userRole = role;
    }

    //I am not sure any of the things below should be public, I will change them once I have more details regarding the project
    public string ID {get;set;} //This should check for ID validity
    public string userName{get;set;} //This should search for the userName
    public string passWord{get;set;} //This should check if password matches the userName
    public Role userRole{get;set;} //This is just for storing roles
}