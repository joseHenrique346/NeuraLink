using Refit;

namespace Arguments;

public interface ITesteRefit
{
    [Post("/treinar/")]
    Task<ApiResponse<RespostaTreino>> TrainAsync([Body] TrainData data);

    [Post("/consultar_multa/")]
    Task<ApiResponse<RespostaConsulta>> AskQuestionAsync([Body] AskedQuestion question);
}

public class TrainData
{
    public string Pergunta { get; set; }
    public string Query { get; set; }
}

public class AskedQuestion
{
    public string question { get; set; }
}

public class RespostaTreino
{
    public string Mensagem { get; set; }
    public float Loss { get; set; }
}

public class RespostaConsulta
{
    public string Resposta { get; set; }
}