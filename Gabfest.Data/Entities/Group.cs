namespace Gabfest.Data;

public class Group : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Avatar { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<Message> Messages { get; set; }
}
