namespace fusogram_csharp.Dtos
{
    public class LoginRespostaDto
    {   // Este é um DTO (Data Transfer Object) usado para representar informações de resposta de login em respostas da API.

        public string Nome { get; set; }  // Propriedade para armazenar o nome do usuário
        public string Email { get; set; } // Propriedade para armazenar o email do usuário
        public string Token { get; set; } // Propriedade para armazenar o token de autenticação

        // Este DTO é usado para serializar informações de resposta de login em respostas da API, permitindo que o cliente receba informações sobre o usuário autenticado, juntamente com o token necessário para acesso a recursos protegidos.
    }
}
