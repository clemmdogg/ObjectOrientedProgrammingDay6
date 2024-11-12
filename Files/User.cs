using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingDay6.Files;

internal class User : IComparable<User>
{
    public string FirstName {  get; init; }
    public string LastName { get; init; }
    public int Age { get; init; }
    public string Email { get; init; }
    public User(string firstName, string lastName, int age, string email)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Email = email;
    }
    public int CompareTo(User other)
    {
        if (other == null)
            return 1;

        return string.Compare(this.LastName, other.LastName, StringComparison.Ordinal);
    }
}
