using System;

namespace ContentBadRequestVsUnprocessableEntity.Services.Abstractions
{
    public class BussinessException : Exception
    {
        public string ErrorCode { get; set; }
        public string Description { get; set; }

        private BussinessException(string errorCode, string description)
        {
            ErrorCode = errorCode;
            Description = description;
        }

        public static BussinessException UserIsInactive() => new BussinessException("0001", "User status is INACTIVE");
        public static BussinessException AccountIsClosed() => new BussinessException("0002", "Account is CLOSED");
    }
    public static class BussinessExceptionExtensions
    {
        public static void Launch(this BussinessException exception) => throw exception;
    }
}
