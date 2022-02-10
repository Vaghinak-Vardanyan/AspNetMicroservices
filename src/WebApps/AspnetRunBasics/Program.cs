using AspnetRunBasics.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient<ICatalogService, CatalogService>(client =>
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:GatewayAddress")));

builder.Services.AddHttpClient<IBasketService, BasketService>(client =>
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:GatewayAddress")));

builder.Services.AddHttpClient<IOrderService, OrderService>(client =>
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiSettings:GatewayAddress")));

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
