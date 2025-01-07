using System;
using Healthcare_Management_System.Models;

namespace Healthcare_Management_System.Services;

public class UserService
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public User AuthenticateUser(string username, string password)
    {
        return users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }

    public User GetUserById(int id)
    {
        return users.FirstOrDefault(u => u.Id == id);
    }

    public void DisplayUsers()
    {
        foreach (var user in users)
        {
            user.DisplayInfo();
        }
    }
}
