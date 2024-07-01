using System.ComponentModel.DataAnnotations;

namespace Gabfest.Data;

public class User : BaseEntity
{
    [StringLength(50)]
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    [StringLength(100)]
    public string FullName { get; set; }
    public string? Avatar { get; set; }
    public string? Role { get; set; }
    public string? ConnectionId { get; set; }
    public ICollection<Message> Messages { get; set; }
    public ICollection<Group> Groups { get; set; }
}
