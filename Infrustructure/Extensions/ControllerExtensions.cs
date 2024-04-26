using Core;
using Infrustructure.ErrorHandling.Errors.Base;
using Microsoft.AspNetCore.Mvc;

public static class ControllerExtensions
{
    public static IActionResult CreateResponse<T>(this ControllerBase controller, Result<T, Error> result)
    {
        return result._isSuccess ? controller.Ok(result._value) : controller.BadRequest(result._error);
    }
}