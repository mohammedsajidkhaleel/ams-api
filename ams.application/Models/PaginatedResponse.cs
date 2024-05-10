namespace ams.application.Models;

public sealed class PaginatedResponse<T>
{
    public int TotalItems { get; set; } = 0;
    public IReadOnlyList<T> Items { get; set; } = new List<T>();
}
