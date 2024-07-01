namespace Gabfest.Services;

public record MessageModel
{
    public string Content { get; init; }
    public int? UserId { get; init; }
    public int? GroupId { get; init; }
}
