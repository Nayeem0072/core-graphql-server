using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversalMagicClient.Entities
{
    public class SocialNetwork
    {
        public string NickName { get; set; }
        public string Url { get; set; }
        public Author Author { get; set; }
    }    
}
