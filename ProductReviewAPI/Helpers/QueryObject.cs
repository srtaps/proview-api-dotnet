namespace ProductReviewAPI.Helpers
{
    public class QueryObject
    {
        public string? productName { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool isDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
