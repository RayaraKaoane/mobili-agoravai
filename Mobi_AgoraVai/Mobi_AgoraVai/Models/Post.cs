using System;
namespace Mobi_AgoraVai.Models
{
    // Models/Post.cs
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlImagem { get; set; }
        public string Description { get; set; }
        public string UrlNew { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }

}

