using Microsoft.AspNetCore.Components;
using MyBlog.Core;

namespace MyBlog.Components
{
    public partial class UserInfoComponent
    {
        [CascadingParameter] GitHubUserInfo UserInfo { get; set;  }

        [Parameter] public bool ShowAvatar { get; set; } = true;

        [Parameter] public bool ShowDetails { get; set; } = true;

    }
}
