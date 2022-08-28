namespace Core.Models;

public class User
{
    public long Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }


    public long RoleId { get; set; }
    public virtual Role Role { get; set; }
}