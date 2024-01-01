using LeaveManagement.Data;
using Leavemanagement.Mapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LeaveManagement.Services;
using LeaveManagement.Contracts;
using Microsoft.AspNetCore.Identity.UI.Services;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddHttpContextAccessor();
// builder.Services.AddIdentityCore<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
// 	.AddEntityFrameworkStores<ApplicationDbContext>();
// builder.Services.AddTransient<IEmailSender>(s => new EmailSender("localhost", 25, "no-reply@leavemanagement.com"));

builder.Services.AddScoped(typeof(IGeneric<>), typeof(GenericService<>)); 
builder.Services.AddScoped<ILeaveType, LeaveTypeService>();
builder.Services.AddScoped<ILeaveAllocation, LeaveAllocationService>();
builder.Services.AddScoped<ILeaveRequest, LeaveRequestService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Host.UseSerilog((ctx, lc) => 
    lc.WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));

// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

app.UseSerilogRequestLogging();
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
app.MapRazorPages();
app.Run();
