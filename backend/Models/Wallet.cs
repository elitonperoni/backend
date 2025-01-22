using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace backend.Models;

[Table("wallet")]
public class Wallet
{
    public Wallet(int userId, double valorAtual, string banco, DateTime ultimaAtualizacao)
    {
        this.UserId = userId;
        this.ValorAtual = valorAtual;
        this.Banco = banco.Trim().ToUpper();
        this.UltimaAtualizacao = ultimaAtualizacao;
    }
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }
    public double ValorAtual { get; set; }

    [Required]
    public string Banco { get; set; } = null!;

    public DateTime UltimaAtualizacao { get; set; }

    [JsonIgnore]
    public User? user { get; set; } 
}
