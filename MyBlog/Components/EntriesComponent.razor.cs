using Microsoft.AspNetCore.Components;
using MyBlog.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlog.Components
{
    public partial class EntriesComponent : ComponentBase
    {
        [Inject] protected IInformationProvider InformationService { get; set; }
        public List<GitHubSearchResult.Item> Entries { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var result = await InformationService.GetLastEntriesAsync();
            Entries = result.items;
        }
    }
}
