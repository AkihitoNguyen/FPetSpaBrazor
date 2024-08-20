using FPetSpaBrazor.Client.Pages;
using FPetSpaBrazor.Components;
using FPetSpaBrazor.DAL;
using FPetSpaBrazor.DAL.Data;
using FPetSpaBrazor.DLL.Services.ProductServices;
using Microsoft.EntityFrameworkCore;

namespace FPetSpaBrazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();
            //Add Controller
            builder.Services.AddControllers();


            builder.Services.AddDbContext<FpetSpaBrazorContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("FpetSpaBrazor"));
            });

            

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Add Entity Services
            builder.Services.AddScoped<IProductServices, ProductServices>();
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.Configuration["ApiBaseAddress"])
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.MapControllers();
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
