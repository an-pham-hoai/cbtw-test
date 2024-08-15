using Backend.Share.DTO.Interfaces;
using Backend.Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEO.Domain.Interfaces
{
    public interface ISEOService
    {
        Task<ISEOInfoDTO> GetSeoInfo(string query, SearchProvider searchProvider);
    }
}
