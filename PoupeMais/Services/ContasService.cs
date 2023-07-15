using PoupeMais.Dao;

namespace PoupeMais.Services
{
    public class ContasService
    {
        private readonly ApplicationDbContext _contexto;

        public ContasService(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public List<TipoGasto> ListarTipoGasto()
        {
            var items = _contexto.TipoGasto.OrderBy(x => x.Id);

            var tipos = items.ToList();

            return tipos;
        }
        public string ListarTipoGastoPorId(int id)
        {
           var tipogasto = _contexto.TipoGasto.FirstOrDefault(g => g.Id == id);

            return tipogasto.Descricao;
        }
        public List<Recorrencia> ListarRecorrencia()
        {
            var items = _contexto.Recorrencia.OrderBy(x => x.Id);

            var tipos = items.ToList();

            return tipos;
        }
        public string ListarRecorrencoaPorId(int id)
        {
            var recorrencia = _contexto.Recorrencia.FirstOrDefault(g => g.Id == id);

            return recorrencia.Descricao;
        }
        public List<Gastos> ListarGastosPorUsuario(int userId)
        {
            var tipos = new List<Gastos>();
            if (_contexto.Gastos.Any())
            {
                var items = _contexto.Gastos.Where(x => x.IdUsuario == userId);
                tipos = items.ToList();
            }


            return tipos;
        }
        public void AdicionarGasto(Gastos gasto)
        {
            _contexto.Gastos.Add(gasto);
            _contexto.SaveChanges();
        }
        public void EditarGasto(Gastos gasto)
        {
            var gastos = _contexto.Gastos.First(g => g.Id == gasto.Id);
            gastos.IdTipoGasto = gasto.IdTipoGasto;
            gastos.IdRecorrencia = gasto.IdRecorrencia;
            gastos.Valor = gasto.Valor;
            gastos.Descricao = gasto.Descricao;
            gastos.DtVencimento = gasto.DtVencimento;
            gastos.IdUsuario = gasto.IdUsuario;

            _contexto.SaveChanges();
        }
        public void DeletarGasto(int id)
        {
            var line = _contexto.Gastos.SingleOrDefault(item => item.Id == id);
            _contexto.Gastos.Remove(line);   
            _contexto.SaveChanges();
        }
    }
}
