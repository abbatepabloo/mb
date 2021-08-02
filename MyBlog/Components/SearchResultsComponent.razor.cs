using Microsoft.AspNetCore.Components;
using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyBlog.Components
{
    public partial class SearchResultsComponent
    {
        [Inject] protected IInformationProvider InformationService { get; set; }
        [Inject] protected NavigationManager NavigationManagerService { get; set; }

        [Parameter] public string SearchKeyword { get; set; }

        protected List<GitHubSearchResult.Item> FoundItems;
        protected int TotalItems;
        protected int From;

        protected override Task OnParametersSetAsync()
        {
            return SearchItemsAsync();
        }

        protected  async Task SearchItemsAsync()
        {
            if (!string.IsNullOrEmpty(SearchKeyword))
            {
                var results = await InformationService.SearchInFileContentAsync(SearchKeyword, From, 5);
                FoundItems = results.items;
                TotalItems = results.total_count;
                StateHasChanged();
            }
            else
            {
                FoundItems = null;
            }
        }

        protected async Task MoreItems()
        {
            From += 5;
            await SearchItemsAsync();
        }

        protected void GotoEntry(string gitUrl, string path)
        {
            SearchKeyword = null;
            NavigationManagerService.NavigateTo($"entry/{HttpUtility.UrlEncode(gitUrl)}/{HttpUtility.UrlEncode(path)}");
        }

    }
}
