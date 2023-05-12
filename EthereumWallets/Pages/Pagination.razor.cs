using EthereumWallets.Domain.Pagination;
using EthereumWallets.Pagination;
using Microsoft.AspNetCore.Components;

namespace EthereumWallets.Pages
{
    public partial class Pagination
    {
        private List<PagingLink> _links;

        [Parameter]
        public PaginationModel Metadata { get; set; }

        [Parameter]
        public int Spread { get; set; }

        [Parameter]
        public EventCallback<int> SelectedPage { get; set; }

        protected override void OnParametersSet()
        {
            CreatePaginationLinks();
        }

        private void CreatePaginationLinks()
        {
            _links = new List<PagingLink>();
            _links.Add(new PagingLink(Metadata.CurrentPage - 1, Metadata.HasPrevious, "Previous"));

            for (int i = 1; i <= Metadata.TotalPages; i++)
            {
                if (i >= Metadata.CurrentPage - Spread && i <= Metadata.CurrentPage + Spread)
                {
                    _links.Add(new PagingLink(i, true, i.ToString())
                    {
                        Active = Metadata.CurrentPage == i
                    });
                }
            }

            _links.Add(new PagingLink(Metadata.CurrentPage + 1, Metadata.HasNext, "Next"));
        }

        private async Task OnSelectedPage(PagingLink link)
        {
            if (link.Page == Metadata.CurrentPage || !link.Enabled)
            {
                return;
            }

            Metadata.CurrentPage = link.Page;
            await SelectedPage.InvokeAsync(link.Page);
        }
    }
}
