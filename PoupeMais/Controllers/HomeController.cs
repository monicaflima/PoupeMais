using Microsoft.AspNetCore.Mvc;
using PoupeMais.Services;
using PoupeMais.ViewModel;

namespace PoupeMais.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly ContasService _contasService;

        public HomeController(UsuarioService usuarioService, ContasService contasService)
        {
            _usuarioService = usuarioService;
            _contasService = contasService;
        }


        public IActionResult Index()
        {
            var userId = (int)HttpContext.Session.GetInt32("UserId");
            var user = _usuarioService.BuscarUsuarioPorId(userId);
            AtualizaContas(userId);
            HomeViewModel model = new HomeViewModel
            {
                Nome = user.Nome,
            };
            return View(model);
        }

        public void AtualizaContas(int id)
        {
            var gastosUsuario = _contasService.ListarGastosPorUsuario(id);
            foreach (var gastos in gastosUsuario)
            {
                if (gastos.DtVencimento < DateOnly.FromDateTime(DateTime.Now))
                {
                    var recorrencia = _contasService.ListarRecorrencoaPorId(gastos.IdRecorrencia);
                    switch (recorrencia)
                    {
                        case "Mensal":
                            gastos.DtVencimento = gastos.DtVencimento.AddMonths(1);
                            _contasService.EditarGasto(gastos);
                            break;
                        case "Semanal":
                            gastos.DtVencimento = gastos.DtVencimento.AddDays(7);
                            _contasService.EditarGasto(gastos);
                            break;
                    }
                }
            }
        }
    }
}