using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalMVC.Models.Enuns;

namespace PersonalMVC.Models
{
    public class AcessorioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Modelo { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Materiais { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Valor { get; set; }
        public TipoAcessoriosEnum TipoAcessorios { get; set; }
        public int? ViolinoId { get; set; }
        public ViolinoViewModel? Violino { get; set; }
    }
}