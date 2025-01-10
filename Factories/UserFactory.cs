using System;
using Healthcare_Management_System.Models;

namespace Healthcare_Management_System.Factories;

public class UserFactory: IUserFactory
{
    public User CreateUser(int id, string username, string password, string role)
    {
        switch (role.ToLower())
        {
            case "admin":
                return new User { Id = id, Username = username, Password = password, Role = "admin" };
            case "doctor":
                return new User { Id = id, Username = username, Password = password, Role = "doctor" };
            case "nurse":
                return new User { Id = id, Username = username, Password = password, Role = "nurse" };
            case "patient":
                return new User { Id = id, Username = username, Password = password, Role = "patient" };
            default:
                throw new ArgumentException("Invalid role type.");
        }
    }

    internal object CreateUser(string v1, string v2, string v3)
    {
        throw new NotImplementedException();
    }
}
