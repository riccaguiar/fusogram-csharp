namespace fusogram_csharp.Dtos
{
    public class ErrorRespostaDto
    {        // Este é um DTO (Data Transfer Object) usado para representar informações de erro em respostas da API.

        public int Status { get; set; }  // Propriedade para armazenar o status da resposta (código de status HTTP)
        public string Descricao { get; set; }  // Propriedade para armazenar a descrição da resposta (mensagem de erro)
        public List<string> Erros { get; set; }  // Lista de mensagens de erro adicionais (opcional)

        // Esse DTO é usado para serializar informações de erro em respostas da API, permitindo uma comunicação clara dos problemas que ocorreram durante o processamento de uma solicitação.
    }
}
