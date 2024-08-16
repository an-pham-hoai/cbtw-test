using Backend.Shared.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEO.Domain.Interfaces
{
    public interface IFetchService
    {
        Task<IFetchDTO> Fetch(string url);
    }
}
