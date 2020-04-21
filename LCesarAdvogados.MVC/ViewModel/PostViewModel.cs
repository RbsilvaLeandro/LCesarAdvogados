using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LCesarAdvogados.MVC.ViewModel
{
    public class PostViewModel
    {
        [Key]    
        public int IdPost { get; set; }

        [Required(ErrorMessage = "Preencha o campo Título")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        [DisplayName("Título")]
        public string TituloPost { get; set; }

        [Required(ErrorMessage = "Preencha o campo Resumo")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo 2 caracteres")]
        [DisplayName("Resumo")]        
        public string ResumoPost { get; set; }

        [Required(ErrorMessage = "Preencha o campo Conteúdo")]      
        [DisplayName("Conteúdo")]
        [AllowHtml]
        [MaxLength]
        public string ConteudoPost { get; set; }


        [Required(ErrorMessage = "Preencha o campo Imagem")]
        [DisplayName("Imagem Post")]
        [AllowHtml]
        [MaxLength]
        public string ImagemPost { get; set; }

        [ScaffoldColumn(false)]        
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public bool Status { get; set; }
    }
}