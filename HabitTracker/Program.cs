using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using HabitTracker;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add MudBlazor
builder.Services.AddMudServices();

// Setup HttpClient with token from sessionStorage
builder.Services.AddScoped<HttpClient>(sp =>
{
    var jsRuntime = sp.GetRequiredService<IJSRuntime>();
    var httpClient = new HttpClient
    {
        BaseAddress = new Uri("http://localhost:5047")
    };

    jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "authToken").AsTask().ContinueWith(task =>
    {
        var token = task.Result;
        if (!string.IsNullOrEmpty(token))
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    });

    return httpClient;
});

await builder.Build().RunAsync();