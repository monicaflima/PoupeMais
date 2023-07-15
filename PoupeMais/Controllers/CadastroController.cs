using Microsoft.AspNetCore.Mvc;
using PoupeMais.Models;
using PoupeMais.Services;

namespace PoupeMais.Controllers
{
    public class CadastroController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly UsuarioService _usuarioService;
        private readonly CriptografiaService _criptografiaService;

        public CadastroController(UsuarioService usuarioService, ILogger<LoginController> logger, CriptografiaService criptografiaService)
        {
            _usuarioService = usuarioService;
            _logger = logger;
            _criptografiaService = criptografiaService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro(string nome, string email, string senha)
        {
            var user = _usuarioService.BuscarUsuarioPorEmail(email);

            if (user != null)
            {
                ViewBag.ErrorMessage = "Usuário já cadastrado";
                return View("Index");
            }

            // Criptografa a senha informada pelo usuário
            string hashedPassword = _criptografiaService.GerarHashSenha(senha);

            try
            {
                _usuarioService.AdicionarUsuario(new Usuario { Nome = nome, Email = email, Senha = hashedPassword });
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = "Erro ao cadastrar usuário";
                return View("Index");
            }

            return RedirectToAction("Index", "Login");
        }

    }
}