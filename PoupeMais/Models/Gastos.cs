using System.ComponentModel.DataAnnotations;

public class Gastos
{

    public int Id { get; set; }
    public int IdUsuario { get; set; }
    public int IdRecorrencia { get; set; }
    public int IdTipoGasto { get; set; }
    public decimal Valor { get; set; }
    public DateTime DtVencimento { get; set; }
    public string Descricao { get; set; }

}