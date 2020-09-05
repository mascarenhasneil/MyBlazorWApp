using System;
using System.Net.Http;
using System.Threading.Tasks;
using Markdig;
using Markdig.SyntaxHighlighting;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BlazorApp1Test
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            // Create Serilog logger with BrowserConsole sink
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.BrowserConsole()
				.CreateLogger();

            builder.Services.AddLogging(builder => builder
				.SetMinimumLevel(LogLevel.Trace));

            builder.Services.AddSingleton<MarkdownPipeline>(
					sp => new MarkdownPipelineBuilder()
						.UseAdvancedExtensions()    // to add other adv. extensions to markdown.  
						.UseSyntaxHighlighting()    // to hight code syntax in its output.
						.Build());    

            await builder.Build().RunAsync();
        }
    }
}
