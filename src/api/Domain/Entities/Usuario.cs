using Domain.Enums;

namespace Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public ETipoUsuario TipoUsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
