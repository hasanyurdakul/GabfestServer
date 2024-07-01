namespace Gabfest.Data;

public class Message : BaseEntity
{
    public string Content { get; set; }
    public int? UserId { get; set; }
    public User User { get; set; }
    public int? GroupId { get; set; }
    public Group Group { get; set; }
}
