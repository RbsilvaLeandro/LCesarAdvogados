
using System.ComponentModel.DataAnnotations;
namespace LCesarAdvogados.MVC.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Login")]
        [MaxLength(30, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]     
        public string Senha { get; set; }
        
    }
}