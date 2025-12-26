namespace StockService.Application.Common.Paginate;

public class PagedResult<T> where T : class
{
    public List<T> Items { get; set; } = new();
    public int PageCount { get; set; }
    public int TotalCount { get; set; }
}