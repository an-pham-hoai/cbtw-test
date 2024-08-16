﻿using Backend.Share.DTO.Implementations;
using Backend.Share.DTO.Interfaces;
using Backend.Share.Enums;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SEO.Domain.Interfaces;

namespace BackendApi.Controllers
{
    /// <summary>
    /// Controller to handle SEO actions
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowSpecificOrigin")]
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
        /// Gets SEO info based on query and search provider (1=Google, 2=Bing).
        /// 
        /// Only Google has real implementation, Bing has mockup one. 
        /// It is placed here for the purpose of making the system easy to expand later.
        /// 
        /// Note: if you receive error: Response status code does not indicate success: 
        /// 429 (Too Many Requests) => please try again after a while because Google has rate limiter.
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
