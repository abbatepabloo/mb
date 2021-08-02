using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Core;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBlog
{
    public class Program
    {
        IConfiguration Configuration { get; }
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IInformationProvider, InformationProvider>();
            builder.Services
                .AddBlazorise(options =>
                    {
                        options.ChangeTextOnKeyPress = true;
                    })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();
            await builder.Build().RunAsync();
        }
    }
}
