using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace user_crud.Error {
  public class GlobalError {
    private readonly RequestDelegate _next;

    public GlobalError(RequestDelegate next) {
      _next = next;
    }

    public async Task Invoke(HttpContext context) {
      try {
        await _next(context);
      } catch (Exception error) {
        var response = context.Response;
        response.ContentType = "application/json";

        string result = "";

        switch(error) {
          case AppError e: 
            response.StatusCode = e.statusCode;

            result = JsonSerializer.Serialize(new { 
              message = e.messageError,
              statusCode = e.statusCode
            });

            break;
          
          default: 
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            result = JsonSerializer.Serialize(new { 
              message = error.Message,
            });

            break;
        }

        await response.WriteAsync(result);
      }
    }
  }
}