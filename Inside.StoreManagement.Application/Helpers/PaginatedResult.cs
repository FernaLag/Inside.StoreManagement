namespace Inside.StoreManagement.Application.Helpers
{
    public class PaginatedResult<T>(List<T> pageResults, int totalResults, int pageNumber, int pageSize)
    {
        public int TotalResults { get; set; } = totalResults;
        public int PageSize { get; set; } = pageSize;
        public int PageNumber { get; set; } = pageNumber;
        public List<T> PageResults { get; set; } = pageResults ?? [];
    }
}