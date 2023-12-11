﻿using MinimalApi.Features.Examples.GetExample;

namespace MinimalApi.Tests.Integration.Tests.Example
{
    [Collection("Endpoint")]
    public class GetExampleEndpointTests(RadEndpointFixture f)
    {
        [Fact]
        public async void When_RequestValid_ReturnsSuccess()
        {
            //Act            
            var (h, r) = await f.Client.GetAsync<GetExampleEndpoint, GetExampleRequest, GetExampleResponse>(new()
            {
                Id = 1
            });

            //Assert
            h.StatusCode.Should().Be(HttpStatusCode.OK);
            r.Should().BeOfType<GetExampleResponse>();           
            r!.Data!.Id.Should().Be(1);
        }

        [Fact]
        public async void Given_ExampleNonExistant_ReturnsProblem()
        {
            //Act            
            var (h, r) = await f.Client.GetAsync<GetExampleEndpoint, GetExampleRequest, ProblemDetails>(new()
            {
                Id = 999
            });

            //Assert
            h.StatusCode.Should().Be(HttpStatusCode.NotFound);
            r.Should().BeOfType<ProblemDetails>();
            r!.Title.Should().Be("Example not found");
        }
        [Fact]
        public async void When_IdInvalid_ReturnsProblem()
        {
            //Act            
            var (h, r) = await f.Client.GetAsync<GetExampleEndpoint, GetExampleRequest, ProblemDetails>(new()
            {
                Id = 0
            });

            //Assert
            h.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            r.Should().BeOfType<ProblemDetails>();
            r!.Extensions.Should().ContainKey("Id");
        }
    }
}
