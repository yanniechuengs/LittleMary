using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // 配置 Serilog
    builder.Host.UseSerilog((context, config) =>
    {
        config.ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7);
    });

    // 添加 Blazor Server 服务
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();

    var app = builder.Build();

    // 配置 HTTP 请求管道
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        app.UseHsts();
        app.UseHttpsRedirection();
    }
    
    app.UseStaticFiles();
    app.UseAntiforgery();

    // 映射 Razor 组件（Blazor Web App 模式）
    app.MapRazorComponents<LittleMary.Web.Components.App>()
        .AddInteractiveServerRenderMode();

    Log.Information("Starting web application");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}