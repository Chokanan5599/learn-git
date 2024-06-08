using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using TLA_SalseForeCast.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<M_TAAX63TEST_DB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TAAX63TEST"));
});

builder.Services.AddDbContext<M_db>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TEST_API"));
});

//builder.Services.AddSession(options =>
//        {
//            options.Cookie.Name = ".MySessionCookie";
//            options.IdleTimeout = TimeSpan.FromSeconds(1200000); // Session timeout duration เซ็ทเวลา ให้ กับ Session ของ WebBorwser
//        });


    // Other middleware configurations

 

    // Other middleware configurations

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDistributedMemoryCache();

//builder.Services.AddSwaggerGen(opt =>
//{
//    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
//    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Description = "Please enter token",
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        BearerFormat = "JWT",
//        Scheme = "bearer"
//    });

//    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type=ReferenceType.SecurityScheme,
//                    Id="Bearer"
//                }
//            },
//            new string[]{}
//        }
//    });
//});
builder.Services.AddSwaggerGen();
builder.Services.AddSession(options =>
{
        options.IdleTimeout = TimeSpan.FromSeconds(1200000);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


//app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
//app.MapControllerRoute( name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute( 
    name: "default",
    //pattern: "{controller=Home}/{action=SalesForeCasst_Dashboard}/{id?}"
    //pattern: "{controller=Home}/{action=Form_Fill_Date}/{id?}"
//pattern: "{controller=Home}/{action=SalesForeCast}/{id?}"
//pattern: "{controller=Home}/{action=Login}/{id?}"
pattern: "{controller=Home}/{action=SalesForeCasst_Detail}/{id?}"
);

app.Run();
    