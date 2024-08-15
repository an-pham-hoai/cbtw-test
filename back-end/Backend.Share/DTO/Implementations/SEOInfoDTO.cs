using Backend.Share.DTO.Interfaces;
using Backend.Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Share.DTO.Implementations
{
    public class SEOInfoDTO : ISEOInfoDTO
    {
        public SearchProvider SearchProvider { get; set; }
        public string Query { get; set; }
        public int Rank { get; set; }
        public string Error { get; set; }
    }
}
