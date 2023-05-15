namespace ServicesStore.Api.Authors.ApiResult
{
    public class ApiBasicResult
    {
        public ApiBasicResult(bool isSuccessful, string message)
        {
            this.IsSuccessful = isSuccessful;
            this.Message = message;
        }

        public ApiBasicResult(Exception? exception)
        {
            this.Message = exception is null ? "Null exception" : $"{exception.Message}\n\n{exception.StackTrace}";
        }

        public bool IsSuccessful { get; init; }

        public string Message { get; init; } = string.Empty;
    }
}
