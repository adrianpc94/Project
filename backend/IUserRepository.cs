namespace backend;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
    User Get(int id);
}
