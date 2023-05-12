using EthereumWallets.Domain.Models;
using EthereumWallets.Domain.Pagination;
using EthereumWallets.Extensions;
using EthereumWallets.Services;
using Microsoft.AspNetCore.Components;

namespace EthereumWallets.Pages
{
    public partial class Wallets
    {
        private const string UpArrow = "<img src=\"/images/up.png\" height=\"10px\" style=\"margin: 0px 0px 0px 5px;\"/>";
        private const string DownArrow = "<img src=\"/images/down.png\" height=\"10px\" style=\"margin: 0px 0px 0px 5px;\"/>";

        private readonly PaginationParameters _paginationParameters;
        private string _currentArrow;

        public Wallets()
        {
            _currentArrow = UpArrow;
            _paginationParameters = new PaginationParameters();
            WalletList = new List<Wallet>();
            Metadata = new PaginationModel();
        }

        [Inject]
        public IEthereumWalletService? WalletsService { get; set; }

        public List<Wallet> WalletList { get; set; }
        public PaginationModel Metadata { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetWallets();
        }

        protected override void OnParametersSet()
        {
            GetRecords();
        }

        public void Sort()
        {
            if (_paginationParameters.OrderBy == "asc")
            {
                _paginationParameters.OrderBy = "desc";
                _currentArrow = DownArrow;
            }
            else
            {
                _paginationParameters.OrderBy = "asc";
                _currentArrow = UpArrow;
            }

            GetRecords();
        }

        private void GetRecords()
        {
            WalletList = WalletList.Sort(_paginationParameters.OrderBy).ToList();
        }

        private async Task SelectedPageCallback(int page)
        {
            _paginationParameters.PageNumber = page;
            WalletList.Clear();
            await GetWallets();
        }

        private async Task GetWallets()
        {
            var pagingResponse = await WalletsService!.GetPaginatedWallets(_paginationParameters);
            WalletList = pagingResponse.Wallets;
            Metadata = pagingResponse.Metadata;
        }
    }
}
