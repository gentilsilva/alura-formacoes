using System.Reflection;
using FilmesApi.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

/*
 * Utilizado para configurar o banco de dados.
 */
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

builder.Services.AddDbContext<FilmeContext>(opcoes => opcoes.UseLazyLoadingProxies() // Adicionar para carregamento Lazy
    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

/*
 * Utilizado para utilizar o automaper
 */
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.

/*
 * AddNewTonsoftJson é utilizado para requisições http patch.
 */
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

/*
 * Para adicionar mais informações ao swagger, modificar o AddSwaggerGen
 * É necessário incluir GenerateDocumentationFile -> true no csproj 
 */
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "FilmesAPI", Version = "v1"});
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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