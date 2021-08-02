using Microsoft.AspNetCore.Components;
using MyBlog.Core;
using System.Threading.Tasks;

namespace MyBlog.Pages
{
    public partial class Entry
    {
        [Inject] IInformationProvider InformationService {  get; set; }
        [Parameter] public string GitUrl { get; set; }
        [Parameter] public string Path { get; set; }
    }
}
