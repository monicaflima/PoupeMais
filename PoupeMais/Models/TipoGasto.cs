using System.ComponentModel.DataAnnotations;

public class TipoGasto
{
    public TipoGasto(string descricao)
    {
        Descricao = descricao;
    }

    public int Id { get; set; }

    [Required]
    public string Descricao { get; set; }

}