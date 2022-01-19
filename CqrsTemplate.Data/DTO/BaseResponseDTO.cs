using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsTemplate.Data.DTO
{
    public class BaseResponseDTO
    {
        public bool IsSuccess { get; set; }
        public string[] Errors { get; set; }
    }
}
