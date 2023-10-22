using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fusogram_csharp.Controllers
{
    // Atributo [Authorize] especifica que a autenticação é necessária para acessar as ações deste controlador.
    [Authorize]
    public class BaseController : ControllerBase
    {
        // Esta classe serve como uma base para outros controladores.
        // Qualquer controlador derivado de BaseController herda a exigência de autenticação.

        // ControllerBase é a classe base para controladores sem suporte a exibições.
        // Ele fornece funcionalidades básicas para controladores da Web API.

        // O [Authorize] atributo garante que apenas usuários autenticados possam acessar as ações deste controlador.

        // Qualquer ação em controladores derivados de BaseController exigirá autenticação para ser acessada.
    }
}
