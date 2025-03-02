using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxLink
{
    /// <summary>
    /// История запросов и ответов при работе с Кларком
    /// </summary>
    public class ClarkHistory
    {
        public static List<string> UserRequests { get; set; } = new List<string>();
        public static List<string> ClarkAnswers { get; set; } = new List<string>();
    }
}
