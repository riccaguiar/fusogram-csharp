namespace fusogram_csharp.Dtos
{
    public class LoginRequisicaoDto
    {   // Este é um DTO (Data Transfer Object) usado para representar informações de requisição de login.

        public string Email { get; set; }  // Propriedade para o email de login
        public string Senha { get; set; }  // Propriedade para a senha de login

        // Este DTO é frequentemente usado como entrada em operações de login em uma API, permitindo que o cliente forneça as informações necessárias para autenticação.
    }
}
