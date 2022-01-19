using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsTemplate.Core.Excepitons
{
    public class InvalidRequestBodyException : Exception
    {
        public string[] Errors { get; set; }
    }
}
