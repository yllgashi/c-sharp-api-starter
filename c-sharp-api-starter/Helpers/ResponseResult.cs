namespace c_sharp_api_starter.Helpers
{
    public class ResponseResult
    {
        public bool IsError { get; set; }
        public string? Message { get; set; }
        public object? Result { get; set; }

        public static ResponseResult Success(object result)
        {
            ResponseResult response = new ResponseResult();
            response.IsError = false;
            response.Message = null;
            response.Result = result;
            return response;
        }

        public static ResponseResult Error(string? message)
        {
            ResponseResult response = new ResponseResult();
            response.IsError = true;
            response.Message = message;
            return response;
        }
    }
}
