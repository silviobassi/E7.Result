﻿using System.Net;

namespace E7.EasyResult.Errors;

/// <summary>
/// Represents an error that occurs when an object is not found.
/// </summary>
/// <author>Silvio Luiz Bassi</author>
/// <company>Enfatiza7 Consultoria em Tecnologia LTDA</company>
public sealed class ElementNotFoundError()
    : AppError("Object not found.", ErrorType.NotFoundRule, nameof(ElementNotFoundError))
{
    /// <summary>
    /// Gets the list of error messages.
    /// </summary>
    /// <returns>A list containing the detail message of the error.</returns>
    public override List<object> GetErrorsMessage() => [Detail];

    /// <summary>
    /// Gets the HTTP status code associated with the error.
    /// </summary>
    /// <returns>The HTTP status code for not found (404) <see cref="Result{T}"/>.</returns>
    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
}