using fusogram_csharp;
using fusogram_csharp.Models;
using fusogram_csharp.Repository;
using fusogram_csharp.Repository.Impl;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a controllers na aplicação
builder.Services.AddControllers();
// Adiciona suporte a geração de documentação de API com Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Obtém a string de conexão do arquivo de configuração
var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
// Configura o contexto do Entity Framework Core com a string de conexão
builder.Services.AddDbContext<FusogramContext>(option => option.UseSqlServer(connectionstring));

// Registra uma implementação do repositório de usuário
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositoryImpl>();
builder.Services.AddScoped<ISeguidorRepository, SeguidorRepositoryImpl>();
builder.Services.AddScoped<IPublicacaoRepository, PublicacaoRepositoryImpl>();
builder.Services.AddScoped<IComentarioRepository, ComentarioRepositoryImpl>();

// Configura a chave de criptografia para o JWT
var chaveCriptografia = Encoding.ASCII.GetBytes(ChaveJWT.ChaveSecreta);

// Configura a autenticação baseada em JWT
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

// Configuração para ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona todas as requisições HTTP para HTTPS
app.UseHttpsRedirection();
// Habilita a autenticação baseada em JWT
app.UseAuthentication();
// Habilita a autorização
app.UseAuthorization();
// Mapeia os controladores para suas respectivas rotas
app.MapControllers();
app.Run();
