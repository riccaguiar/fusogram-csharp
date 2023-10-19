using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fusogram_csharp.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        
    }
}
