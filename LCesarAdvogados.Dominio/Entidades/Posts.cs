using System;

namespace LCesarAdvogados.Dominio.Entidades
{
    public class Posts
    {
        public int IdPost { get; set; }
        public string TituloPost { get; set; }
        public string ImagemPost { get; set; }
        public string ConteudoPost { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Status { get; set; }
        public string ResumoPost { get; set; }
    }
}
