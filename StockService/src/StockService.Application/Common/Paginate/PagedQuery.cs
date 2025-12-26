namespace StockService.Application.Common.Paginate;

public class PagedQuery
{
    public int PageNumber { get; set; } = 0;
    public int PageSize { get; set; } = 20;
}