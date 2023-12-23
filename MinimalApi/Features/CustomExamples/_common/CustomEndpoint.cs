﻿using Microsoft.AspNetCore.Http.HttpResults;

namespace MinimalApi.Features.CustomExamples._common
{
    public abstract class CustomEndpoint<TRequest, TResponse> : RadEndpoint<TRequest, TResponse>
        where TResponse : RadResponse, new()
        where TRequest : RadRequest
    {
        protected override void SendOk() => TypedResults.Ok("This is a different implementation of the Ok helper.");
        protected override void SendNotFound(string message) => TypedResults.NotFound(message);
    }
}
