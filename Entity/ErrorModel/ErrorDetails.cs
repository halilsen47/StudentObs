using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity.ErrorModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        
        public virtual string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
