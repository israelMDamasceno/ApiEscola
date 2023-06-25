using Domain.Enums;

namespace Domain.ViewModel
{
    public class UsuarioViewModel
    {
        public int PessoaId { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public ETipoUsuario TipoUsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public bool Ativo { get; set; }
    }
}
