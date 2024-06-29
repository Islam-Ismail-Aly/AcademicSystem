namespace Academic.Application.Utilities
{
    public class APIResponseResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public int TotalPages { get; set; }
        public int StatusCode { get; set; }

        public APIResponseResult(T data, string message = null, int totalPages = 0)
        {
            Success = true;
            Data = data;
            Message = message;
            TotalPages = totalPages;
        }

        public APIResponseResult(string message, int statusCode = 400)
        {
            Success = false;
            Message = message;
            StatusCode = statusCode;
        }

        public APIResponseResult(int statusCode, string message = null)
        {
            Success = false;
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource wasn't found",
                500 => "Errors are the path to the dark side. Errors lead to anger",
                _ => null,
            };
        }
    }
}
