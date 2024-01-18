using HRAPP.Services;
Console.WriteLine("Creating Builder......");
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//External Services Configuration
Console.WriteLine("Configuring Injectable Services with Builder");
//builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
