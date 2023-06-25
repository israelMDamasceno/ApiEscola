namespace Repository.Command
{
    public class CriarTurmaCommand
    {
        public int CursoId { get; set; }
        public string Turma { get; set; }
        public int Ano { get; set; }
        public bool Ativo { get; set; }
    }
}
