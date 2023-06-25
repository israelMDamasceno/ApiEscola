using Repository.Enums;

namespace Repository.Command
{
    public class InsertUsuarioCommand
    {
        public string Nome { get; set; }
        public ETipoUsuario TipoUsuarioId { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
