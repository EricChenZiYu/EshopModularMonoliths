

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration);

var app = builder.Build();

//app.UseExceptionHandler();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule();

app.Run();
