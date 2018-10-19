using layUiAdmin.Controllers.Argument;
using layUiAdmin.Dispatchs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        //修改表格签名字段
        [HttpPost]
        public async Task<IActionResult> modifySignColumn(ArguModifySignColumn arguModifySignColumn)
        {
            ServerDispatch serverDispatch = new ServerDispatch();
            return Json(await serverDispatch.ModifySign(arguModifySignColumn));
        }
    }
}