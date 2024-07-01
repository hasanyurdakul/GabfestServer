namespace Gabfest.Services;

public record MessageCreateModel
{
    public string Content { get; init; }
    public int? UserId { get; init; }
    public int? GroupId { get; init; }
}
