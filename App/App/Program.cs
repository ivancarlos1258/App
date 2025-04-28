using TargetApp;
using App.Domain.HttpClient;
using Microsoft.AspNetCore.Authentication.Cookies;
using Refit;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<HeaderTokenHandler>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(x =>
{
    x.LoginPath = "/Auth/Login"; // CASO NAO ESTEJA LOGADO REDIRECIONA PARA ESSE LINK
    x.LogoutPath = "/Auth/Logout"; // CASO ESTEJA LOGADO E QUEIRA DESLOGAR REDIRECIONA PARA ESSE LINK
    x.AccessDeniedPath = "/Erro/NaoAutorizado";  // CASO O USUARIO NAO TENHA PERMISSAO PARA ACESSAR A PAGINA (ROLES)
    x.ExpireTimeSpan = TimeSpan.FromHours(24); // TEMPO QUE O LOGIN DURA NA PAGINA
    x.Cookie.MaxAge = x.ExpireTimeSpan; // DEFINE VIDA MAXIMA PARA COOKIE
    x.SlidingExpiration = true; // RENOVACAO AUTOMATICA
});


builder.Services.AddRefitClient<IApi>()
.ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7014/v1"))
.AddHttpMessageHandler<HeaderTokenHandler>(); //TO-DO

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
