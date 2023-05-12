namespace EthereumWallets.Domain.Pagination
{
    public class PagedList<T> : List<T>
    {
        public PaginationModel Metadata { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            Metadata = new PaginationModel
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber
            };

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int count, int pageNumber, int pageSize)
        {
            var items = source.ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
