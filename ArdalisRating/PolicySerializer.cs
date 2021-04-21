using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    public class PolicySerializer
    {
        public Policy GetPolicyFromJsonString(string policyJson)
        { 
        return JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());
        }
    }
}
