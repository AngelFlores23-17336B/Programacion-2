using WebEmpresa.Components;
using WebEmpresa.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // O .AddInteractiveWebAssemblyComponents() según tu plantilla

// 1. Configurar HttpClient hacia tu ApiEmpresaV2
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7231/") // Revisa el puerto real de tu API
});

// 2. Registrar el servicio de Clientes
builder.Services.AddScoped<ClienteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// 3. Iniciar la aplicación (Línea indispensable para evitar que 'Exited' ocurra al instante)
app.Run();