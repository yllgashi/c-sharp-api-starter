using Microsoft.AspNetCore.Mvc;

namespace c_sharp_api_starter.Controllers
{
    public class BaseController : ControllerBase
    {
        public string UserId
        {
            get { return User.Claims.Where(c => c.Type == "UserId").Select(x => x.Value).FirstOrDefault(); }
        }
    }
}
