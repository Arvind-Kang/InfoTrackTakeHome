using InfoTrackScraper;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ScrapingRequestHandler>();

var host = builder.Build();
host.Run();
