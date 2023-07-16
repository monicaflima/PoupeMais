namespace PoupeMais.ViewModel
{
    public class ContasViewModel
    {
        public List<TipoGasto> TiposGasto { get; set; }
        public List<Recorrencia> Recorrencias { get; set; }
        public List<GastosModel> Gastos { get; set; }
    }

    public class GastosModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TipoId { get; set; }
        public int RecorrenciaId { get; set; }
        public string Tipo { get; set; }
        public DateTime DtVencimento { get; set; }
        public decimal Valor { get; set; }
    }
}
﻿