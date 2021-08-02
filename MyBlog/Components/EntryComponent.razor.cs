using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyBlog.Core;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyBlog.Components
{
    public partial class EntryComponent
    {
        [Inject] protected IInformationProvider InformationService { get; set; }
        [Inject] protected IJSRuntime JsInterop { get; set; }

        [Parameter] public string GitUrl { get; set; }
        [Parameter] public string Path { get; set; }
        [Parameter] public bool ExcerptView { get; set; }
        protected GitHubCommitInfo CommitInfo { get; set; }

        protected MarkupString HtmlContent;

        protected async override Task OnParametersSetAsync()
        {
            HtmlContent = new MarkupString(await InformationService.GetMarkDownContentInHtmlFormat(GitUrl, ExcerptView));
            CommitInfo = await InformationService.GetCommitInfoAsync(Path);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JsInterop.InvokeVoidAsync("Prism.highlightAll");
        }

        protected string GetNavigationUrl()
{
            return $"/Entry/{HttpUtility.UrlEncode(GitUrl)}/{HttpUtility.UrlEncode(Path)}";
        }
    }
}