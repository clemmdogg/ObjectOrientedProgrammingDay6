﻿using ObjectOrientedProgrammingDay6;
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

string firstName = "";
string lastName = "";
int age = 0;
string email = "";
bool isMatchingTheConditions = true;
Console.Write("Indtast fornavn: ");
try
{
    firstName = Console.ReadLine();
    if (firstName == null || firstName.Length == 0)
        throw new InvalidNameException("Fornavn må ikke være tomt!!");
}
catch (InvalidNameException ex1)
{
    Console.WriteLine($"Fejl: {ex1}");
    isMatchingTheConditions = false;
}
catch (Exception ex2)
{
    Console.WriteLine($"Fejl: {ex2}");
    isMatchingTheConditions = false;
}
Console.Write("Indtast efternavn: ");
try
{
    lastName = Console.ReadLine();
    if (lastName == null || lastName.Length == 0)
        throw new InvalidNameException("Efternavn må ikke være tomt!!");
}
catch (InvalidNameException ex3)
{
    Console.WriteLine($"Fejl: {ex3}");
    isMatchingTheConditions = false;
}
catch (Exception ex4)
{
    Console.WriteLine($"Fejl: {ex4}");
    isMatchingTheConditions = false;
}
Console.Write("Indtast alder: ");
try
{
    if (!(int.TryParse(Console.ReadLine(), out age)) || (!(age >= 18 && age <= 50)))
        throw new InvalidAgeException("Alder skal være mellem 18 og 50!!");
}
catch (InvalidAgeException ex5) when (!(firstName.ToLower() == "niels" && lastName.ToLower() == "olesen"))
{
    Console.WriteLine($"Fejl: {ex5}");
    isMatchingTheConditions = false;
}
catch (InvalidOperationException ex6)
{
    Console.WriteLine($"Fejl: {ex6}");
    isMatchingTheConditions = false;
}
catch (Exception)
{
    Console.WriteLine($"Fordi det er dig, Niels, så får den lov at passere!!");
}

Console.Write("Indtast email: ");
try
{
    email = Console.ReadLine();
    if (email == null || email.Length == 0 || !email.Contains("@") || !email.Contains("."))
    {
        ArgumentException innerEx = new ArgumentException("Email er ikke korrekt formateret.");
        throw new InvalidEmailException("Email må ikke være tomt og skal indeholde @ og .!!", innerEx);
    }
}
catch (InvalidEmailException innerEx)
{
    Console.WriteLine($"Inner exception: {innerEx.InnerException}");
    Console.WriteLine($"Custom message exception: {innerEx.Message}");
    isMatchingTheConditions = false;
}
catch (Exception ex8)
{
    Console.WriteLine($"Fejl: {ex8}");
    isMatchingTheConditions = false;
}
string binDirectory = AppDomain.CurrentDomain.BaseDirectory;
string projectRootDirectory = Path.GetFullPath(Path.Combine(binDirectory, @"..\..\..\"));
string usersFilePath = Path.Combine(projectRootDirectory, "Files", "Users.txt");

if (isMatchingTheConditions)
{
    User newUser = new User(firstName, lastName, age, email);
    if (File.Exists(usersFilePath))
    {
        File.AppendAllText(usersFilePath, $"{newUser.FirstName}, {newUser.LastName}, {newUser.Age}, {newUser.Email}" + Environment.NewLine);
    }
    else
    {
        Console.WriteLine("Filen blev ikke fundet. Ny er oprettet!!");
        using (FileStream fs = File.Create(usersFilePath)) { }
        File.AppendAllText(usersFilePath, $"{newUser.FirstName}, {newUser.LastName}, {newUser.Age}, {newUser.Email}" + Environment.NewLine);
    }
}
Console.WriteLine("-----------------------");
Console.WriteLine("Her er alle brugere:");
if (File.Exists(usersFilePath))
    {
    Console.WriteLine(File.ReadAllText(usersFilePath)); }
Console.WriteLine("-----------------------");
Console.WriteLine("Programmet er afsluttet!!");

