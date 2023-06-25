namespace Repository.ViewModel
{
    public class ResponseApi<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }

    public class ResponseApiList<T>
    {
        public bool Success { get; set; }
        public DadosCursoData data { get; set; }
    }

    public class DadosCursoData
    {
        public IEnumerable<CursoViewModel> Values { get; set; }
    }


}
