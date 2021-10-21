using CoffeeMakerApi.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoffeeMakerApi.Tests
{
    public class ApiCallTrackerTests
    {
        [Fact]
        public void TestApiCallTrackerFor1Call()
        {
            var apiCallTrackerService = new ApiCallTrackerService(1);
            apiCallTrackerService.IncrementApiCallCount();
            var result = apiCallTrackerService.ApiShouldReturnUnavailable();
            Assert.True(result);
        }

        [Fact]
        public void TestAreYouATeaPotTrue5Calls()
        {
            var apiCallTrackerService = new ApiCallTrackerService(5);

            apiCallTrackerService.IncrementApiCallCount();
            var result = apiCallTrackerService.ApiShouldReturnUnavailable();
            Assert.False(result);

            apiCallTrackerService.IncrementApiCallCount();
            result = apiCallTrackerService.ApiShouldReturnUnavailable();
            Assert.False(result);

            apiCallTrackerService.IncrementApiCallCount();
            result = apiCallTrackerService.ApiShouldReturnUnavailable();
            Assert.False(result);

            apiCallTrackerService.IncrementApiCallCount();
            result = apiCallTrackerService.ApiShouldReturnUnavailable();
            Assert.False(result);

            apiCallTrackerService.IncrementApiCallCount();
            result = apiCallTrackerService.ApiShouldReturnUnavailable();
            Assert.True(result);
        }
    }
}
