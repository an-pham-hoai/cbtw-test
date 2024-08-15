using Backend.Share.DTO.Implementations;
using Backend.Share.DTO.Interfaces;
using Backend.Share.Enums;
using Microsoft.AspNetCore.Mvc;
using SEO.Domain.Interfaces;

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
        private readonly ISEOService seoService;

        /// <summary>
        /// Constructor to initialize SEOController with dependencies
        /// </summary>
        /// <param name="logger">Log service</param>
        /// <param name="seoService"></param>
        public SEOController(ILogger<SEOController> logger, ISEOService seoService)
        {
            this.logger = logger;
            this.seoService = seoService;
        }

        /// <summary>
        /// Gets SEO info based on query and search provider
        /// </summary>
        /// <returns>The result SEOInfo</returns>
        /// <response code="200">Returns the list of items</response>
        /// <response code="400">If the request is invalid</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<ISEOInfoDTO> Post(string query, SearchProvider searchProvider)
        {
            return seoService.GetSeoInfo(query, searchProvider);
        }
    }
}
