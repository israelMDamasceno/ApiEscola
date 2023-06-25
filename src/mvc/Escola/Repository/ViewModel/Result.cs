namespace Repository.ViewModel
{
    public class ResponseApi<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
