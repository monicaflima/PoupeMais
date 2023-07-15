using Microsoft.AspNetCore.Mvc;
using PoupeMais.ViewModel;
using PoupeMais.Services;

namespace PoupeMais.Controllers
{
    public class ContasController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly UsuarioService _usuarioService;
        private readonly ContasService _contasService;
        private readonly CriptografiaService _criptografiaService;

        public ContasController(UsuarioService usuarioService, ILogger<LoginController> logger, CriptografiaService criptografiaService, ContasService contasService)
        {
            _usuarioService = usuarioService;
            _logger = logger;
            _criptografiaService = criptografiaService;
            _contasService = contasService;
        }


        public IActionResult Index()
        {
            List<GastosModel> gastosUsuario = new List<GastosModel>();
            var gastosMes = _contasService.ListarGastosPorUsuario((int)HttpContext.Session.GetInt32("UserId"));
            foreach (var gastos in gastosMes)
            {
                if (gastos.DtVencimento.Month == DateTime.Now.Month)
                {
                    GastosModel gasto = new GastosModel
                    {
                        Id = gastos.Id,
                        Nome = gastos.Descricao,
                        DtVencimento = gastos.DtVencimento,
                        Valor = gastos.Valor,
                        Tipo = _contasService.ListarTipoGastoPorId(gastos.IdTipoGasto),
                        TipoId = gastos.IdTipoGasto,
                        RecorrenciaId = gastos.IdRecorrencia
                    };
                    gastosUsuario.Add(gasto);
                }
            }
            ContasViewModel model = new ContasViewModel
            {
                TiposGasto = _contasService.ListarTipoGasto(),
                Recorrencias = _contasService.ListarRecorrencia(),
                Gastos = gastosUsuario
            };
            return View(model);
        }
        public IActionResult AdicionarGasto(string nome, int tipo, string valor, int recorrencia, DateTime dtvencimento)
        {
            if(nome != null && tipo != 0 && valor !=null & recorrencia != 0 && dtvencimento != DateTime.MinValue)
            {
                Gastos gasto = new Gastos
                {                    
                    Descricao = nome,
                    IdRecorrencia = recorrencia,
                    IdTipoGasto = tipo,
                    DtVencimento = DateOnly.FromDateTime(dtvencimento),
                    Valor = decimal.Parse(valor.Replace(".", ",")),
                    IdUsuario = (int)HttpContext.Session.GetInt32("UserId")
                };


                _contasService.AdicionarGasto(gasto);
            }
            
            return RedirectToAction("Index", "Contas");
        }
        public IActionResult EditarGasto(int id, string nome, int tipo, string valor, int recorrencia, DateTime dtvencimento)
        {

            Gastos gasto = new Gastos
            {
                Id = id,
                Descricao = nome,
                IdRecorrencia = recorrencia,
                IdTipoGasto = tipo,
                DtVencimento = DateOnly.FromDateTime(dtvencimento),
                Valor = decimal.Parse(valor.Replace(".", ",")),
                IdUsuario = (int)HttpContext.Session.GetInt32("UserId")
            };
            _contasService.EditarGasto(gasto);
            return RedirectToAction("Index", "Contas");
        }
        public IActionResult DeletarGasto(int id)
        {
            _contasService.DeletarGasto(id);

            return RedirectToAction("Index", "Contas");
        }
    }
}