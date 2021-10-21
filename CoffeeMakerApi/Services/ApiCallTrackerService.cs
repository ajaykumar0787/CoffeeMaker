using CoffeeMakerApi.ServiceContracts;

namespace CoffeeMakerApi.Services
{
    public class ApiCallTrackerService : IApiCallTrackerService
    {

        private int ApiCallCount { get; set; }
        private readonly int _callCountToReturnUnavailable;

        public ApiCallTrackerService(int callCountToReturnUnavailable)
        {
            _callCountToReturnUnavailable = callCountToReturnUnavailable <= 0 ? 1 : callCountToReturnUnavailable;
        }

        public void IncrementApiCallCount()
        {
            ApiCallCount++;
        }

        public bool ApiShouldReturnUnavailable()
        {
            return ApiCallCount % _callCountToReturnUnavailable == 0;
        }
    }
}
