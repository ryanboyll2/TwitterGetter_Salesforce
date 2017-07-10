using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TwitterGetter.Models;
using TwitterGetter.Util;

namespace TwitterGetter.Controllers
{
    [RoutePrefix("api/tweets")]
    public class TwitterController : ApiController
    {
        // GET api/values
        [Route("{user:alpha}/{count:int}/{filter:alpha?}")]
        public async Task<IEnumerable<Tweet>> Get(string user, int count, string filter = "")
        {
            var tweets = await TwitterServices.GetTweets(user, count, filter, string.Empty);
            return tweets;
        }
    }
}
