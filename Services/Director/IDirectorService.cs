using System.Security.Claims;

namespace UmbrellaCorpHRSystem.Services.Director
{
    public interface IDirectorService
    {
        Task InitiatePizzaPartyProtocol();
        Task InitiateSelfDestruct();
    }
}
