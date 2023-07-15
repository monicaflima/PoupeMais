using Microsoft.AspNetCore.Mvc;
using PoupeMais.Services;

namespace PoupeMais.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly ContasService _gastosService;
        private readonly CriptografiaService _criptografiaService;

        public LoginController(UsuarioService usuarioService, CriptografiaService criptografiaService, ContasService gastosService)
        {
            _usuarioService = usuarioService;
            _criptografiaService = criptografiaService;
            _gastosService = gastosService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string email, string senha)
        {
            var user = _usuarioService.BuscarUsuarioPorEmail(email);

            if (user == null)
            {
                ViewBag.ErrorMessage = "Usuário ou senha inválidos";
                return View("Index");
            }

            string hashedPassword = _criptografiaService.GerarHashSenha(senha);

            if (user.Senha != hashedPassword)
            {
                ViewBag.ErrorMessage = "Usuário ou senha inválidos";
                return View("Index");
            }


            HttpContext.Session.SetInt32("UserId", user.Id);

            return RedirectToAction("Index", "Home");
        }

    }
}