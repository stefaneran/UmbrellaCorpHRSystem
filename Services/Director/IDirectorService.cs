using System.Security.Claims;

namespace UmbrellaCorpHRSystem.Services.Director
{
    public interface IDirectorService
    {
        /// <summary>
        /// Initiate the Pizza Party Protocol which kicks off the main event of the narrative (Infecting most of the office and receiving the Admin password)
        /// </summary>
        Task InitiatePizzaPartyProtocol();

        /// <summary>
        /// Initiate the Self Destruct Protocol which purges the facility
        /// </summary>
        Task InitiateSelfDestruct();
    }
}
