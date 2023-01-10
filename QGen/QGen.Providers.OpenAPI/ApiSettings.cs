using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QGen.Providers.OpenAPI;
public class ApiSettings
{
    public string ApiKey { get; set; } = "";
    public float Temperature { get; set; } = 0.1f;
    public float TopP { get; set; } = 0.7f;
    public int MaxTokens { get; set; } = 500;
}
