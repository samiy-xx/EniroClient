namespace EniroClient.Api
{
    public class ApiResult<T>
        where T : class
    {
        public T Content { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
