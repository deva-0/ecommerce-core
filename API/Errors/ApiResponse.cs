namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Provides custom messages for each type of error.
        /// </summary>
        /// <param name="statusCode">HTTP error code.</param>
        /// <returns>Custom message for error with provided code</returns>
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side. " +
                    "Errors lead to anger. Anger leads to hate." +
                    "Hate leads to career change",
                _ => null
            };
        }

    }
}