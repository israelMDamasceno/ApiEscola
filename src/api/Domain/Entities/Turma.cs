namespace Domain.Entities
{
    public class Turma
    {
        public int TurmaId { get; set; }
        public int CursoId { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public bool Ativo { get; set; }
    }
}

