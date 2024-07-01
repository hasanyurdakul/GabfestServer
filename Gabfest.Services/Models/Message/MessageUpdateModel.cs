namespace Gabfest.Services;

public record MessageUpdateModel
{
    public int Id { get; init; }
    public string Content { get; init; }
    public int? UserId { get; init; }
    public int? GroupId { get; init; }
}
