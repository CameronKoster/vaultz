using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class VaultKeep
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    [Required]
    public int VaultId { get; set; }
    [Required]
    public int KeepId { get; set; }


  }
}