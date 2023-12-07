using System;
namespace Mobi_AgoraVai.Models
{
    // Models/Calculadora.cs
    public class Calculadora
    {
        public int Id { get; set; }
        public decimal ItemValue { get; set; }
        public DateTime ItemEmission { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }


}

