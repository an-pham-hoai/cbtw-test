using Backend.Shared.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Shared.DTO.Implementations
{
    public class FetchDTO : IFetchDTO
    {
        public string Content { get; set; }
        public string Error { get; set; }
    }
}
