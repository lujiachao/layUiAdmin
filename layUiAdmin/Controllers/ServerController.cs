using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using layUiAdmin.Argument;
using layUiAdmin.Dispatchs;
using layUiAdmin.Result;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace layUiAdmin.Controllers
{
    [EnableCors("AllowCors")]
    [Route("api/[controller]/[action]")]
    public class ServerController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> getJsonData()
        {
            ServerDispatch valuesDispatch = new ServerDispatch();
            return Json(await valuesDispatch.List());
        }

        [HttpGet]
        public async Task<IActionResult> pageTest(ArguPage arguPage)
        {
            ServerDispatch valuesDispatch = new ServerDispatch();
            return Json(await valuesDispatch.pagelist(arguPage));
        }

        //重载数据，更新数据
        [HttpGet]
        public async Task<IActionResult> pageReloadTest(ArguPage arguPage)
        {
            ServerDispatch serverDispatch = new ServerDispatch();
            return Json(await serverDispatch.pageReloadList(arguPage));
        }
    }
}