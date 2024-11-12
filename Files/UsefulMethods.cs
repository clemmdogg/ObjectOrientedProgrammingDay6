using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingDay6.Files;

internal class UsefulMethods
{
    public static List<User> CreateUserAndGetUserList(string usersFilePath)
    {
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
            Console.WriteLine($"Inner exception: {innerEx.ToString()}");
            isMatchingTheConditions = false;
        }
        catch (Exception ex8)
        {
            Console.WriteLine($"Fejl: {ex8}");
            isMatchingTheConditions = false;
        }
        List<User> users = new List<User>();
        if (File.Exists(usersFilePath))
        {
            users = DeserializeUsers(usersFilePath);
            if (isMatchingTheConditions)
            {
                User newUser = new User(firstName, lastName, age, email);
                users.Add(newUser);
            }
            SerializeUsers(users, usersFilePath);
        }
        else
        {
            Console.WriteLine("Filen blev ikke fundet. Ny er oprettet!!");
            using (FileStream fs = File.Create(usersFilePath)) { }
            if (isMatchingTheConditions)
            {
                User newUser = new User(firstName, lastName, age, email);
                users.Add(newUser);
            }
            SerializeUsers(users, usersFilePath);
        }
        return users;

    }
    public static void SerializeUsers(List<User> users, string usersFilePath)
    {
        string jsonString = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(usersFilePath, jsonString);
    }

    public static List<User> DeserializeUsers(string usersFilePath)
    {
        string jsonString = File.ReadAllText(usersFilePath);
        return JsonSerializer.Deserialize<List<User>>(jsonString);
    }

}
