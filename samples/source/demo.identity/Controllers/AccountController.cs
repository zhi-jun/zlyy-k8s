using demo.identity.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace demo.identity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityServerInteractionService _interaction;
        public AccountController()
        {
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            var context = await _interaction.GetAuthorizationContextAsync(model.ReturnUrl);
            //if (context != null)
            {
                // if the user cancels, send a result back into IdentityServer as if they 
                // denied the consent (even if this client does not require consent).
                // this will send back an access denied OIDC error response to the client.
                await _interaction.GrantConsentAsync(context, ConsentResponse.Denied);
                return Redirect(model.ReturnUrl);
            }
            return Ok();
        }

        /// <summary>
        /// 外部登陆
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet("external-login")]
        public IActionResult ExternalLogin(string returnUrl)
        {
            var props = new AuthenticationProperties()
            {
                RedirectUri = Url.Action("Callback"),
                Items =
                {
                   { "returnUrl", returnUrl }
                }
            };
            return Challenge(props);
        }
    }
}
