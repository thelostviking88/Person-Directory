namespace PersonDirectory.Application.Models;

/// <summary>
/// Paged responce model
/// </summary>
/// <typeparam name="T">type</typeparam>
/// <param name="data">data</param>
/// <param name="pageNumber">page number</param>
/// <param name="pageSize">page size</param>
/// <param name="totalRecords">total records</param>
public class PagedResponseDto<T>(IEnumerable<T> data, int pageNumber, int pageSize, int totalRecords)
{
    /// <summary>
    /// Collection of data
    /// </summary>
    public IEnumerable<T> Data { get; set; } = data;

    /// <summary>
    /// Current page number
    /// </summary>
    public int PageNumber { get; set; } = pageNumber;

    /// <summary>
    /// Size of each page (number of items per page)
    /// </summary>
    public int PageSize { get; set; } = pageSize;

    /// <summary>
    /// Total number of records available
    /// </summary>
    public int TotalRecords { get; set; } = totalRecords;
}