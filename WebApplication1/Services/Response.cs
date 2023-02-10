using Dapper;

namespace WebApplication1.Services
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public int Code { get; set; }
        public DynamicParameters? param { get; set; }   
        public string? Message { get; set; }
    }
}
