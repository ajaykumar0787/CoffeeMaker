namespace CoffeeMakerApi.ServiceContracts
{
    public interface IApiCallTrackerService
    {
        void IncrementApiCallCount();
        bool ApiShouldReturnUnavailable();
    }
}
