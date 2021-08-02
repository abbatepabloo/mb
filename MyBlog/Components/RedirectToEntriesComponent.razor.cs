using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Components
{
    public partial class RedirectToEntriesComponent
    {
        [Inject] NavigationManager NavigationManagerService { get; set; }
        protected override void OnInitialized()
        {
            NavigationManagerService.NavigateTo("entries");
        }
    }
}
