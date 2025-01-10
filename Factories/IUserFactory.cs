using System;
using Healthcare_Management_System.Models;

namespace Healthcare_Management_System.Factories;

public interface IUserFactory
{
    User CreateUser(int id, string username, string password, string role);
} 
