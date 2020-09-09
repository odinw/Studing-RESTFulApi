using Microsoft.AspNetCore.Mvc;
using RESTFulApi.Protocol;

namespace RESTFulApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public object Index() => "Studing RESTFulApi";



        /* Query Parameter */

        /// <summary>
        /// Query Parameter : string
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public object GetMemberByNickname(string nickname)
        {
            return nickname;
        }

        /// <summary>
        /// Query Parameter : enum.
        /// When parameter range over then that enum, then response message "The value 'parameter value' is invalid."
        /// </summary>
        /// <param name="zone"></param>
        /// <returns></returns>
        [HttpGet("[action]")]
        public object GetMemberByZone(Zone zone)
        {
            return zone.ToString();
        }



        /* Path Variable */

        [HttpGet("[action]/{nickname}")]
        public object MemberByNickname(string nickname)
        {
            return nickname;
        }

        [HttpGet("[action]/{zone}")]
        public object MemberByZone(Zone zone)
        {
            return zone.ToString();
        }

        [HttpGet("[action]/{zone}/{nickname}")]
        public object MemberByZone(Zone zone, string nickname)
        {
            return new
            { 
                Zone = zone,
                Nickname = nickname
            };
        }



        /* Body Parameter */

        [HttpGet("[action]")]
        public object Member([FromBody] MemberParameter memberParameter)
        {
            return memberParameter;
        }



        /* Mix : Path Variable & Body Parameter */

        [HttpGet("[action]/{zone}/{channal}")]
        public object Member(Zone zone, string channal, [FromBody] MemberParameter memberParameter)
        {
            return new
            {
                Zone = zone.ToString(),
                Channal = channal,
                MemberParameter = memberParameter
            };
        }

    }
}
