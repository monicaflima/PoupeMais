using Microsoft.AspNetCore.Mvc;
using PoupeMais.Services;
using PoupeMais.ViewModel;
using PoupeMais.Models;


namespace PoupeMais.Controllers
{
    public class PerfilController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly CriptografiaService _criptografiaService;

        public PerfilController(UsuarioService usuarioService, CriptografiaService criptografiaService)
        {
            _usuarioService = usuarioService;
            _criptografiaService = criptografiaService;
        }


        public IActionResult Index()
        {
            var user = _usuarioService.BuscarUsuarioPorId((int)HttpContext.Session.GetInt32("UserId"));
            PerfilViewModel model = new PerfilViewModel
            {
                Nome = user.Nome,
                Email = user.Email,
                Senha = user.Senha,
                RendaFixa = 10000
            };
            return View(model);
        }
        public IActionResult Atualizar(string email, string senha, string nome, string rendafixa)
        {
            var user = _usuarioService.BuscarUsuarioPorId((int)HttpContext.Session.GetInt32("UserId"));

            Usuario newUser = new Usuario
            {
                Id = user.Id,
                Email = user.Email != email ? email : user.Email,
                Senha = user.Senha != senha ? _criptografiaService.GerarHashSenha(senha) : user.Senha,
                Nome = user.Nome != nome ? nome : user.Nome
            };
            if(user.Nome != newUser.Nome || user.Email != newUser.Email || user.Senha != newUser.Senha)
                _usuarioService.AtualizarUsuario(newUser);

            return RedirectToAction("Index", "Home");
        }

    }
}