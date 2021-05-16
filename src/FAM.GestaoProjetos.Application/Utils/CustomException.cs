using System;
using System.Net;

namespace FAM.GestaoProjetos.Application.Utils
{
    public class CustomException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        private CustomException(HttpStatusCode statusCode, string message) :  base(message)
        {
            StatusCode = statusCode;
        }


        public static CustomException BadRequest(string message) =>
            new CustomException(HttpStatusCode.BadRequest, message);

        public static CustomException ValidationError(string message) =>
            new CustomException(HttpStatusCode.UnprocessableEntity, message);

        public static CustomException EntityNotFound(string message) =>
            new CustomException(HttpStatusCode.NotFound, message);
    }
}
