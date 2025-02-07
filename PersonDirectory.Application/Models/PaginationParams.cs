namespace PersonDirectory.Application.Models;

/// <summary>
/// Pagination parameters
/// </summary>
public class PaginationParams
{
    /// <summary>
    /// Maximum allowed page size
    /// </summary>
    private const int MaxPageSize = 50;

    /// <summary>
    /// Page number
    /// </summary>
    public int PageNumber { get; set; } = 1;

    private int _pageSize = 10;

    /// <summary>
    /// Page size
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
}