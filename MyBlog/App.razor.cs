using Microsoft.AspNetCore.Components;
using MyBlog.Core;
using System.Threading.Tasks;

namespace MyBlog
{
    public partial class App
    {
        [Inject] public IInformationProvider InformationService { get; set; }
        [Inject] public NavigationManager NavigationManagerService { get; set; }

        public GitHubUserInfo UserInfo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            UserInfo = await InformationService.GetUserInfoAsync();
            NavigationManagerService.LocationChanged += NavigationManagerService_LocationChanged;
            if (NavigationManagerService.Uri == NavigationManagerService.BaseUri)
            {
                RedirectToEntries();
            }
        }

        private void NavigationManagerService_LocationChanged(object sender, Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs e)
        {
            if (e.Location == NavigationManagerService.BaseUri) RedirectToEntries();
        }

        private void RedirectToEntries()
        {
            NavigationManagerService.NavigateTo("entries");
        }
    }
}
