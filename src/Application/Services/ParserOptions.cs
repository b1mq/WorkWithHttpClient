using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Application.Services
{
    public  class ParserOptions
    {
        public static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };
    }
}
