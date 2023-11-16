using _01_Exercise.Models;
using System.Linq.Expressions;

namespace _01_Exercise.Interfaces;

// Interface som bestämmer vilka funktioner som ska finnas med i programmet. 
internal interface IUserService
{
    public void CreateUser(UserCreateRequest userCreateRequest);
    public User GetUser(Func<User, bool> expression);
    public IEnumerable<User> GetUsers();
    public bool DeleteUserByEmail(string email);
}
