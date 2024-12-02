using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalMVC.Models;

namespace PersonalMVC.Models
{
public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? Foto { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime? DataAcesso { get; set; }

        public string PasswordString { get; set; } = string.Empty;
        public List<ViolinoViewModel> Violinos { get; set; }
        = new List<ViolinoViewModel>();
        public string Perfil { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}