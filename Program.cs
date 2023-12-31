using finanza_backend_net.Models;
using finanza_backend_net.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options  =>
{
    options.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
    {
        Description = "Encabezado de autorización de JWT usando el esquema Bearer. \r\n\r\n Ingrese 'Bearer' [espacio] y luego su token en la entrada de texto a continuación. \r\n\r\n Ejemplo: \" Bearer 12345abcdef \"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
    });
});

builder.Services.AddDbContext<ExpenseControlContext>(
    o =>
    {
        o.UseSqlServer(builder.Configuration.GetConnectionString("finanzaLocal"));
    });

builder.Services.AddCors(o => o.AddPolicy("AllowAnyCorsPolicy", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();

}));

builder.Services.AddTransient<IuserService,userService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
