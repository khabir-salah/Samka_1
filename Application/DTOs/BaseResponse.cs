

namespace Application.DTOs
{
    public  record BaseResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
    }

    public record BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
