namespace c_sharp_api_starter.Helpers
{
    public class ResponseResult<T>
    {
        public bool IsError { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }

        public static ResponseResult<T> Success(T result)
        {
            ResponseResult<T> response = new ResponseResult<T>();
            response.IsError = false;
            response.Message = null;
            response.Result = result;
            return response;
        }

        public static ResponseResult<T> Error(string? message)
        {
            ResponseResult<T> response = new ResponseResult<T>();
            response.IsError = true;
            response.Message = message;
            return response;
        }

    }
}
