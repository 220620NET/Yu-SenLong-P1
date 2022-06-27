using userModels;
using customExceptions;
using ticketModels;

User Mike = new User(1, "Mike", "1234", Role.Employee);
Console.WriteLine("Mike is a: " + Mike.userRole);

Ticket Test = new Ticket("I flew first class and broke into the captains cabinet", 1, 1, 1);
Console.WriteLine("The ticket is currently {0}.", Test.status);
