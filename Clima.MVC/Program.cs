using Clima.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Garante que o appsettings.json será lido corretamente (boa prática)
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// 🔹 Recupera a connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 🔹 Validação para evitar erro silencioso
if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada.");
}

// 🔹 Configura o DbContext com Oracle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

// 🔹 MVC padrão
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Exibe detalhes do erro no navegador
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// 🔹 Rota padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Evento}/{action=Index}/{id?}");

app.Run();
