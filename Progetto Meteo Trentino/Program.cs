using SoapCore;
using Progetto_Meteo_Trentino.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddSoapCore();
builder.Services.AddScoped<IMeteoService, MeteoService>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.UseSoapEndpoint<IMeteoService>
               ("/MeteoService.wsdl", new SoapEncoderOptions(), SoapSerializer.XmlSerializer));


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Meteo}/{action=Index}/{id?}");

app.Run();
