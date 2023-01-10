using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QGen.Providers.OpenAPI;
public class ApiSettings
{
    public string ApiKey { get; set; } = "";
    public double? Temperature { get; set; } = 0.1;
    public double? TopP { get; set; } = 0.7;
    public int? MaxTokens { get; set; } = 3900;
}
