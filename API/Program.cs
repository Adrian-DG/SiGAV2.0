using System.Text;
using API.Constants;
using API.Services;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

string _customPolicy = "customPolicy";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "SiGAV API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddCors(opt => opt.AddPolicy(_customPolicy, b => {
    b.AllowAnyOrigin(); // TODO: must change after
    b.AllowAnyHeader();
    b.AllowAnyMethod();
    b.WithExposedHeaders("content-disposition");
}));

builder.Services.AddDbContext<MainContext>(opt => {    
    opt.UseSqlite(builder.Configuration.GetConnectionString(builder.Environment.IsProduction() ? "ProdConnection" : "DevConnection"), b => b.MigrationsAssembly("API"));
    //opt.UseSqlServer(builder.Configuration.GetConnectionString(builder.Environment.IsProduction() ? "ProdConnection" : "DevConnection"), b => b.MigrationsAssembly("API"));
});

builder.Services.GetApplicationServices(builder.Configuration, builder.Environment);

// identity requirements

builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt => {
   opt.SignIn.RequireConfirmedAccount = false;
   opt.Password.RequireNonAlphanumeric = false;
   opt.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<MainContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme =JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters() 
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration[JwtBearerConstants.Jwt_Audience],
        ValidIssuer = builder.Configuration[JwtBearerConstants.JWT_ISSUER],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration[JwtBearerConstants.JWT_KEY]))
    };
});

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseDeveloperExceptionPage();
   app.UseSwagger();
   app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseCors(_customPolicy);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();