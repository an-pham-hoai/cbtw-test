using Backend.Share.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Share.DTO.Interfaces
{
    public interface ISEOInfoDTO
    {
        SearchProvider SearchProvider { get; set; }
        string Query { get; set; }
        int Rank { get; set; }
        string Error { get; set; }
    }
}
