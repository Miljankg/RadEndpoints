﻿using Microsoft.AspNetCore.Http;

namespace RadEndpoints
{
    public interface IRadMediator
    {
        Task<IResult> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken)
            where TRequest : RadRequest
            where TResponse : RadResponse, new();
    }
}
