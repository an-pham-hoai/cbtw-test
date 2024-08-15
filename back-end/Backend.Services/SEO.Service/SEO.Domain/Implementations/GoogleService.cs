using Backend.Share.DTO.Implementations;
using Backend.Share.DTO.Interfaces;
using SEO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEO.Domain.Implementations
{
    public class GoogleService : IGoogleService
    {
        public Task<ISEOInfoDTO> GetSeoInfo(string query)
        {
            return Task.FromResult<ISEOInfoDTO>(
                new SEOInfoDTO()
            );
        }
    }
}
