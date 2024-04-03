using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync()
    {
        await Task.Delay(1000);
        return Ok(_userRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        try
        {
            return Ok(_userRepository.Get(id));
        }
        catch (Exception)
        {
            return BadRequest(); 
        }
    }
}