using fusogram_csharp;
using fusogram_csharp.Models;
using fusogram_csharp.Repository;
using fusogram_csharp.Repository.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a controllers na aplica��o
builder.Services.AddControllers();
// Adiciona suporte a gera��o de documenta��o de API com Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Obt�m a string de conex�o do arquivo de configura��o
var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
// Configura o contexto do Entity Framework Core com a string de conex�o
builder.Services.AddDbContext<FusogramContext>(option => option.UseSqlServer(connectionstring));

// Registra uma implementa��o do reposit�rio de usu�rio
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositoryImpl>();
builder.Services.AddScoped<ISeguidorRepository, SeguidorRepositoryImpl>();
builder.Services.AddScoped<IPublicacaoRepository, PublicacaoRepositoryImpl>();
builder.Services.AddScoped<IComentarioRepository, ComentarioRepositoryImpl>();

// Configura a chave de criptografia para o JWT
var chaveCriptografia = Encoding.ASCII.GetBytes(ChaveJWT.ChaveSecreta);

// Configura a autentica��o baseada em JWT
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(autenticacao =>
{
    autenticacao.RequireHttpsMetadata = false;
    autenticacao.SaveToken = true;
    autenticacao.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(chaveCriptografia),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configura��o para ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona todas as requisi��es HTTP para HTTPS
app.UseHttpsRedirection();
// Habilita a autentica��o baseada em JWT
app.UseAuthentication();
// Habilita a autoriza��o
app.UseAuthorization();
// Mapeia os controladores para suas respectivas rotas
app.MapControllers();
app.Run();
