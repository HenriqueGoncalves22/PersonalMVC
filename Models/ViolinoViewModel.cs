using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PersonalMVC.Models;
using System.Text.Json.Serialization;

namespace PersonalMVC.Models
{
    public class ViolinoViewModel
    {
        public int Id { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Materiais { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Valor { get; set; }
        public int? UsuarioId { get; set; }
        public UsuarioViewModel? Usuario { get; set; }
        public List<AcessorioViewModel> Acessorios { get; set; } = [];
    }
}