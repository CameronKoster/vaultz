



using System.ComponentModel.DataAnnotations;

namespace Keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Img { get; set; }
    [Required]
    public int Description { get; set; }
    public int Views { get; set; }
    public int UserID { get; set; }
    public bool IsPrivate { get; set; }
    public int Keeps { get; set; }

  }
}
