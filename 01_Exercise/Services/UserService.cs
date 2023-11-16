using _01_Exercise.Handlers;
using _01_Exercise.Interfaces;
using _01_Exercise.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace _01_Exercise.Services;


// Funktionaliteten bakom de olika menyalternativen. 
internal class UserService : IUserService
{
    private List<User> _users = new List<User>();
    private readonly string path = @"c:\exercise\users.json";

    public void CreateUser(UserCreateRequest userCreateRequest)
    {   
        _users.Add(new User
        {
            Id = Guid.NewGuid(),
            FirstName = userCreateRequest.FirstName,
            LastName = userCreateRequest.LastName,
            Adress = userCreateRequest.Adress,
            Email = userCreateRequest.Email
        });


        FileHandler.SaveToFile(path, JsonConvert.SerializeObject(userCreateRequest));



    }
   
    public IEnumerable<User> GetUsers()
    {
        try
        {
            var users = FileHandler.ReadFromFile(path);
            if (!string.IsNullOrEmpty(users))
            {
                _users = JsonConvert.DeserializeObject<List<User>>(users)!;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return _users;
    }

    public User GetUser(Func<User, bool> expression)
    {
        try
        {
            var user = _users.FirstOrDefault(expression, null!);
            if (user != null)
                return user; 
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }

    public bool DeleteUserByEmail(string email)
    {
        var userToRemove = _users.FirstOrDefault(user => user.Email == email);
        if (userToRemove != null)
        {
            _users.Remove(userToRemove);
            return true;
        }
        return false;
    }
      

}
