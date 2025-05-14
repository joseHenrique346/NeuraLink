using Arguments.Refit.AI;
using NeuraLink.Extension;
using Refit;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var api = RestService.For<INeuraRoadAPI>("http://127.0.0.1:8000");

// Treinar
//var treinoData = new TrainData { Pergunta = "Exemplo?", Query = "MATCH (m) RETURN m" };
//var respostaTreino = await api.TrainAsync(treinoData);
//Console.WriteLine(respostaTreino.Content.Mensagem);

//// Consultar
//var pergunta = new AskedQuestion { question = "Qual a penalidade para X?" };
//var respostaConsulta = await api.AskQuestionAsync(pergunta);
//Console.WriteLine(respostaConsulta.Content.Resposta);

builder.Services.AddJwtAuthentication(
    issuer: "NeuraLink.auth",
    audience: "NeuraLink",
    secretKey: "PR0J3T04P114UN1M4RTR4B4LH01NT3GR4D0R"
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
