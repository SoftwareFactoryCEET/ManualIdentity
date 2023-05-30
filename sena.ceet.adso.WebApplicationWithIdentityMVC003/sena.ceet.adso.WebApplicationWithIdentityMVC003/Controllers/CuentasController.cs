using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using sena.ceet.adso.WebApplicationWithIdentityMVC003.Models;
using sena.ceet.adso.WebApplicationWithIdentityMVC003.Models.ViewModels;

namespace sena.ceet.adso.WebApplicationWithIdentityMVC003.Controllers
{
    public class CuentasController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CuentasController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Registro(string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            RegistroViewModel registroVM = new RegistroViewModel();
            return View(registroVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(RegistroViewModel rgViewModel, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // Create the user
                var usuario = new Usuario
                {
                    UserName = rgViewModel.Email,
                    Email = rgViewModel.Email,
                    Nombres = rgViewModel.Nombres,
                    Apellidos = rgViewModel.Apellidos,
                    Pais = rgViewModel.Pais,
                    Ciudad = rgViewModel.Ciudad,
                    Direccion = rgViewModel.Direccion,
                    FechaNacimiento = rgViewModel.FechaNacimiento,
                    Estado = true //rgViewModel.Estado
                };

                // Create the user in the database
                var resultado = await _userManager.CreateAsync(usuario, rgViewModel.Password);

                if (resultado.Succeeded)
                {
                    // Send the confirmation email
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
                    var urlRetorno = Url.Action("ConfirmarEmail", "Cuentas", new { userId = usuario.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    //await _emailSender.SendEmailAsync(rgViewModel.Email, "Confirmar su cuenta - Proyecto Identity",
                    //    "Por favor confirme su cuenta dando click aquí: <a href=\"" + urlRetorno + "\">enlace</a>");

                    // Sign the user in
                    await _signInManager.SignInAsync(usuario, isPersistent: false);

                    // Redirect to the home page
                    //return RedirectToAction("Index", "Home");
                    return LocalRedirect(returnurl);
                }

                // Validation failed
                ValidarErrores(resultado);
            }

            return View(rgViewModel);
        }

        //Manejador de errores
        private void ValidarErrores(IdentityResult resultado)
        {
            foreach (var error in resultado.Errors)
            {
                ModelState.AddModelError(String.Empty, error.Description);
            }
        }
    }
}
