using Backend.Share.DTO.Implementations;
using Backend.Share.DTO.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    /// <summary>
    /// Controller to handle SEO actions
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SEOController : Controller
    {
        private readonly ILogger<SEOController> logger;

        /// <summary>
        /// Constructor to initialize SEOController with dependencies
        /// </summary>
        /// <param name="logger">Log service</param>
        public SEOController(ILogger<SEOController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Gets all the items.
        /// </summary>
        /// <returns>List of items</returns>
        /// <response code="200">Returns the list of items</response>
        /// <response code="400">If the request is invalid</response>
        [HttpGet(Name = "GetSEO")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ISEOInfoDTO Get()
        {
            return new SEOInfoDTO();
        }
    }
}
