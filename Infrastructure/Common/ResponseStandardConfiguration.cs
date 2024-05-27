using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Infrastructure.Common
{
    public static class ResponseStandardConfiguration
    {
        public static IActionResult StandardizeResponse(
            string message,
            HttpStatusCode status,
            string errorCode,
            object data = null)
        {
            var response = new ApiResponse
            {
                code = errorCode,
                message = message,
                data = data
            };

            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
        public static IActionResult HandleException(Exception ex)
        {
            switch (ex)
            {
                case Exception e when e is ArgumentNullException:
                    return StandardizeResponse("Argument Null Exception", HttpStatusCode.BadRequest, "400");
                case Exception e when e is InvalidOperationException:
                    return StandardizeResponse("Invalid Operation Exception", HttpStatusCode.BadRequest, "400");
                case Exception e when e is UnauthorizedAccessException:
                    return StandardizeResponse("Unauthorized Access Exception", HttpStatusCode.Unauthorized, "401");
                case Exception e when e is KeyNotFoundException:
                    return StandardizeResponse("Key Not Found Exception", HttpStatusCode.NotFound, "404");
                case Exception e when e is Exception:
                    return StandardizeResponse("Internal Server Error", HttpStatusCode.InternalServerError, "500");
                default:
                    return StandardizeResponse("Internal Server Error", HttpStatusCode.InternalServerError, "500");
            }
        }
    }

    public class ApiResponse
    {
        public string code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
