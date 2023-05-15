namespace ServicesStore.Api.Authors.ApiResult
{
    public class ApiOkResult<TResult> : ApiBasicResult
            where TResult : class
    {
        public ApiOkResult(TResult data)
    : base(true, "OK")
        {
            this.Data = data;
        }

        public ApiOkResult(TResult data, string message)
            : base(true, message)
        {
            this.Data = data;
        }

        public TResult? Data { get; init; }
    }
}
