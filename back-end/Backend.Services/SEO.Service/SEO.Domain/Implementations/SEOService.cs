using Backend.Share.DTO.Implementations;
using Backend.Share.DTO.Interfaces;
using Backend.Share.Enums;
using SEO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEO.Domain.Implementations
{
    public class SEOService : ISEOService
    {
        private readonly IGoogleService googleService;
        private readonly IBingService bingService;

        public SEOService(IGoogleService googleService, IBingService bingService) 
        { 
            this.googleService = googleService;
            this.bingService = bingService;
        }

        public async Task<ISEOInfoDTO> GetSeoInfo(string query, SearchProvider searchProvider)
        {
            ISearchService searchService = null;
            switch (searchProvider)
            {
                case SearchProvider.Google:
                    searchService = googleService;
                    break;
                case SearchProvider.Bing:
                    searchService = bingService;
                    break;
            }
            
            if (searchService == null)
            {
                return new SEOInfoDTO()
                {
                    Error = "Search provider not found"
                };
            }

            return await searchService.GetSeoInfo(query);
        }
    }
}
