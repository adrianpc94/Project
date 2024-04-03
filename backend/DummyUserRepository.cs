
using System.ComponentModel;

namespace backend;

public class DummyUserRepository : IUserRepository
{
    private IList<User> _users;

    public DummyUserRepository()
    {
        _users = new List<User>() { 
            new() { Id = 1, Name = "User1" } ,
            new() { Id = 2, Name = "User2" } ,
            new() { Id = 3, Name = "User3" } ,
            new() { Id = 4, Name = "User4" } ,
            new() { Id = 5, Name = "User5" } ,
        };
    }


    public User Get(int id)
    {
        var user = _users.FirstOrDefault(x => x.Id == id) ??
            throw new Exception($"User with id = {id} does not exist.");
        return user;
    }

    public IEnumerable<User> GetAll() => _users;
}
