using userModels;
using customExceptions;
using ticketModels;
using UserData;
using TickeData;

//Start Model test
User Mike = new User(1, "Mike", "1234", Role.Employee);
Console.WriteLine("Mike is a: " + Mike.userRole);

Ticket Test = new Ticket("I flew first class and broke into the captains cabinet", 1, 3, 1, (decimal)100000.11);
Console.WriteLine("The ticket is currently {0}.", Test.status);
//End Model test

//Start user repo test
UserRepository TestRepo = new UserRepository();

//Test Get Create New User
/*try
{
    TestRepo.CreateUser(Mike);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}*/

//Test Get User By ID
try
{
    User ReturnUser = TestRepo.GetUser(0);
    Console.WriteLine(ReturnUser);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

//Test Get All Users
try
{
    List<User> UserList = TestRepo.GetAllUsers();
    foreach(User user in UserList)
    {
        Console.WriteLine(user);
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
//End user repo test

//Start user repo test
//test create Reimbursement
/*TicketRepository TestRepo2 = new TicketRepository();
try
{
    TestRepo2.CreateReimbursement(Test);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}*/
//End user repo test