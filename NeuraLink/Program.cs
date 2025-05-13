//using ApiClient

using Arguments;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var api = RestService.For<ITesteRefit>("http://127.0.0.1:8000");

// Treinar
var treinoData = new TrainData { Pergunta = "Exemplo?", Query = "MATCH (m) RETURN m" };
var respostaTreino = await api.TrainAsync(treinoData);
Console.WriteLine(respostaTreino.Content.Mensagem);

// Consultar
var pergunta = new AskedQuestion { question = "Qual a penalidade para X?" };
var respostaConsulta = await api.AskQuestionAsync(pergunta);
Console.WriteLine(respostaConsulta.Content.Resposta);

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
