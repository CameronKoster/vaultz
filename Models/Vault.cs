using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class Vault
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public string UserID { get; set; }



  }
}