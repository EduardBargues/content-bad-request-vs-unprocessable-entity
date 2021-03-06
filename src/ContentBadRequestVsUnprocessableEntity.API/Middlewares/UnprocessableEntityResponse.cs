namespace ContentBadRequestVsUnprocessableEntity.API.Middlewares
{
    public class UnprocessableEntityResponse
    {
        public string ErrorCode { get; set; }
        public string Description { get; set; }

        public UnprocessableEntityResponse(string errorCode, string description)
        {
            ErrorCode = errorCode;
            Description = description;
        }
    }
}
