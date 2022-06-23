using userModels;
using customExceptions;

User Mike = new User("001", "Mike", "1234", Role.Employee);
Console.WriteLine("Mike is a: " + Mike.userRole);
