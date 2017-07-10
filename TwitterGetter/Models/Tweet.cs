using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterGetter.Models
{
    public class Tweet
    {
        public String user { get; set; }
        public long id { get; set; }
        public String url
        {
            get
            {
                String formattedUrl = String.Format("https://twitter.com/{0}/status/{1}", Uri.EscapeDataString(user), id);
                return Uri.EscapeUriString(formattedUrl);
            }
        }
    }
}