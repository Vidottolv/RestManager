using System.ComponentModel.DataAnnotations;

namespace RestManager.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "O nome excede o tamanho ma'ximo")]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(80, ErrorMessage = "O email excede o tamanho maximo")]
        public string Email { get; set; }
        [Required]
        public int Idade { get; set; }

    }
}
