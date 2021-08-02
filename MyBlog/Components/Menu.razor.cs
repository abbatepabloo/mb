using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyBlog.Classes;
using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlog.Components
{
    public partial class Menu
    {
        [Inject] protected IInformationProvider InformationService { get; set; }
        [Inject] protected IJSRuntime JSRuntime {  get; set; }

        [CascadingParameter] public GitHubUserInfo UserInformation { get; set; }

        protected string SearchKeyword;
        protected ElementReference InputElement;
        protected bool IsSearching;

        protected async override Task OnInitializedAsync()
        {
            UserInformation = await InformationService.GetUserInfoAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.ThrottleEvent(InputElement, "input", TimeSpan.FromMilliseconds(1000));
            }
        }
    }
}
