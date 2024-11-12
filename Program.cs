using ObjectOrientedProgrammingDay6;
using ObjectOrientedProgrammingDay6.Files;

Console.Write("Angiv dit navn: ");
string name = "";
try
{
    name = Console.ReadLine();
    if (name == null || name.Length == 0)
        throw new Exception("Navnefelt skal være udfyldt");
    if (name != "Niels")
        throw new NielsException("Navnet skal være Niels");
}
catch (NullReferenceException ex1)
{

}
catch (Exception ex2)
{
    Console.WriteLine($"Fejl: {ex2.Message}");
}
finally
{
    // Alt i finally block SKAL
    // Det er good practise at designe sig ud af finally
}

Console.Write("Angiv din alder: ");
string strAge = Console.ReadLine();
int output;
bool isNumber = int.TryParse(strAge, out output);
if (!isNumber)
{
    Console.WriteLine($"Fejl: Ikke korrekt format for alder.");
}

Console.WriteLine($"Programmet er afsluttet for brugeren, {name}.");

//------------------------------------------------------------
string binDirectory = AppDomain.CurrentDomain.BaseDirectory;
string projectRootDirectory = Path.GetFullPath(Path.Combine(binDirectory, @"..\..\..\"));
string usersFilePath = Path.Combine(projectRootDirectory, "Files", "Users.json");

List<User> users = UsefulMethods.CreateUserAndGetUserList(usersFilePath);
Console.WriteLine("-----------------------");
Console.WriteLine("Her er alle brugere:");
if (File.Exists(usersFilePath) && users.Count() != 0)
{
    users = UsefulMethods.DeserializeUsers(usersFilePath);
    users.Sort();
    foreach (User user in users)
    {
        Console.WriteLine($"{user.FirstName}\t{user.LastName}\t{user.Age}\t{user.Email}");
    }
}
Console.WriteLine("-----------------------");
Console.WriteLine("Programmet er afsluttet!!");

