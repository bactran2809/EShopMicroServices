using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
// Add service to container
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddRateLimiter(opts =>
{
    opts.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
    });
});

var app = builder.Build();

// Config http request pipeline

app.UseRateLimiter();

app.MapReverseProxy();

app.Run();
