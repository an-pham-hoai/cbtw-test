using Backend.Share.DTO.Implementations;
using Backend.Share.DTO.Interfaces;
using Backend.Share.Enums;
using BackendApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using SEO.Domain.Implementations;
using SEO.Domain.Interfaces;

namespace Backend.Tests
{
    /// <summary>
    /// Tests for SEOController
    /// </summary>
    public class SEOControllerTests
    {
        private readonly SEOController controller;
        private readonly ISEOService seoService;
        private readonly IGoogleService googleService;
        private readonly IBingService bingService;
        private readonly IFetchService fetchService;
        private readonly Mock<ILogger<SEOController>> mockLogger;

        public SEOControllerTests()
        {
            mockLogger = new Mock<ILogger<SEOController>>();
            fetchService = new FetchService();
            googleService = new GoogleService(fetchService);
            bingService = new BingService();
            seoService = new SEOService(googleService, bingService); 
            controller = new SEOController(mockLogger.Object, seoService);
        }

        /// <summary>
        /// Test SEOController Get method - Rank found flow
        /// Search for "land registry search" with Google search engine.
        /// If Google not limits the searching rate, check if Rank has meaningful value or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Get_RankFound()
        {
            var result = await controller.Get("land registry search", SearchProvider.Google);
            Assert.NotNull(result);
            Assert.NotNull(result.Result);

            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.NotNull(okResult.Value);
            var seoInfo = okResult.Value as SEOInfoDTO;
            Assert.NotNull(seoInfo);

            if (!LimitQuota(seoInfo))
            {
                Assert.True(seoInfo.Rank > 0);
            }
        }

        /// <summary>
        /// Test SEOController Get method - Rank not found flow
        /// Search for "land registry search" with Google search engine.
        /// If Google not limits the searching rate, check if Rank is zero or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Get_RankNotFound()
        {
            var result = await controller.Get("latest news from OpenAI", SearchProvider.Google);
            Assert.NotNull(result);
            Assert.NotNull(result.Result);

            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.NotNull(okResult.Value);
            var seoInfo = okResult.Value as SEOInfoDTO;
            Assert.NotNull(seoInfo);

            if (!LimitQuota(seoInfo))
            {
                Assert.True(seoInfo.Rank == 0);
            }
        }

        /// <summary>
        /// Checks if Google applies rate limiting for current request or not
        /// </summary>
        /// <param name="result">The input SEOInfoDTO</param>
        /// <returns>True if Google applied rate limiting, false otherwise</returns>
        private bool LimitQuota(ISEOInfoDTO result)
        {
            return !string.IsNullOrEmpty(result.Error) && result.Error.Contains("Too Many Requests");
        }
    }
}