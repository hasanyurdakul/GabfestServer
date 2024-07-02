namespace Gabfest.Services;

public record GroupUpdateModel
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Avatar { get; set; }
}