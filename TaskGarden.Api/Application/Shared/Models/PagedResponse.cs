namespace TaskGarden.Api.Application.Shared.Models
{
    public class PagedResponse<T>
    {
        public List<T> Items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);


        public PagedResponse(List<T> items, int page, int pageSize, int totalRecords)

        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalRecords = totalRecords;
        }
    }
}