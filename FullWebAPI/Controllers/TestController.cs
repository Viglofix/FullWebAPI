using FullWebAPI.ScopeData;
using FullWebAPI.SingletonData;
using FullWebAPI.TransientData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMorenTempData _morenTempData;
        private readonly ISingletonMorenTempData _SingletonData;
        private readonly IScopeMorenTempData _ScopeMoren;
        public TestController(IMorenTempData _morenTempData, ISingletonMorenTempData _SingletonData, IScopeMorenTempData _ScopeMoren)
        {
            this._morenTempData = _morenTempData;
            this._SingletonData = _SingletonData;
            this._ScopeMoren = _ScopeMoren;
        }
        [HttpGet]
        public ContentResult Index()
        {
            var html = $"<p>{_morenTempData.NameData} -- Jak widac transient DI istnieje tylko podczas konstrukcji instancji </p> <br> <p>{_SingletonData.Name} ---- Singleton zyje do konca dzialania programu</p> <br> <p>{_ScopeMoren.Name}</p>";
            return new ContentResult
            {
                Content = html,
                ContentType = "text/html"
            };
        }
    }
}
