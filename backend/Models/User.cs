using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models;

[Table("user")]
public class User
{
    public User(string nome, string cpf, DateTime nascimento)
    {
        this.Nome = nome.Trim().ToUpper();
        this.Cpf = cpf.Trim();
        this.Nascimento = nascimento;
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [Required]
    [DataType(DataType.Date)]
    public DateTime Nascimento { get; set; }

    [Required]
    [StringLength(100)]
    public string Cpf { get; set; } = null!;

    [JsonIgnore]
    public ICollection<Wallet>? Wallets { get; set; }
}
