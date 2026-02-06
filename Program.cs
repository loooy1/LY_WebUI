using LY_WebUI.Components;

var builder = WebApplication.CreateBuilder(args);

// blazor框架基础服务注册
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); //交互性渲染模式

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

//映射静态资源
app.MapStaticAssets();

//映射 Razor 组件
app.MapRazorComponents<App>().
    AddInteractiveServerRenderMode(); //交互性渲染模式

app.Run();


