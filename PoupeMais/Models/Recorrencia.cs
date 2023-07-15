using System.ComponentModel.DataAnnotations;

public class Recorrencia
{
    public Recorrencia(string descricao)
    {
        Descricao = descricao;
    }

    public int Id { get; set; }

    [Required]
    public string Descricao { get; set; }

}