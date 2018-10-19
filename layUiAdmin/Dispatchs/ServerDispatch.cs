using layUiAdmin.Common.Result;
using layUiAdmin.Controllers.Argument;
using layUiAdmin.Result;
using layUiAdmin.SQL.Entities;
using layUiAdmin.SQL.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace layUiAdmin.Dispatchs
{
    public class ServerDispatch
    {
        public async Task<ResultListData<ResultUser>> List()
        {
            var result = new ResultListData<ResultUser>()
            {
                data = new List<ResultUser>(),
                code = 0,
                msg = "",
                count = 100
            };
            for (int i = 0; i < 100; i++)
            {
                ResultUser resultUser = new ResultUser();
                resultUser.id = i;
                resultUser.username = "User-" + i.ToString();
                resultUser.sex = i % 2 == 0 ? "女" : "男";
                resultUser.city = "城市-" + i.ToString();
                resultUser.sign = "签名-" + i.ToString();
                resultUser.experience = 255;
                resultUser.logins = 24;
                resultUser.wealth = 83289381;
                resultUser.classify = "作家";
                resultUser.score = 55;
                result.data.Add(resultUser);
                result.count = result.data.Count();
            }
            return result;
        }

        public async Task<ResultListData<LayuiData>> pagelist(ArguPage arguPage)
        {
            var result = new ResultListData<LayuiData>()
            {
                data = new List<LayuiData>(),
                code = 0,
                msg = "",
                count = 100
            };
            LayuiDataRepository layuiDataRepository = new LayuiDataRepository();
            result.data = await layuiDataRepository.GetUsersByPage(arguPage.page,arguPage.limit);
            return result;
        }

        //重载数据
        public async Task<ResultListData<LayuiData>> pageReloadList(ArguPage arguPage)
        {
            var result = new ResultListData<LayuiData>()
            {
                data = new List<LayuiData>(),
                code = 0,
                msg = "",
                count = 100
            };
            LayuiDataRepository layuiDataRepository = new LayuiDataRepository();
            result.data = await layuiDataRepository.GetListReload(arguPage.page,arguPage.limit);
            return result;
        }

        //修改签名
        public async Task<ReturnCode> ModifySign(ArguModifySignColumn arguModifySignColumn)
        {
            LayuiDataRepository layuiDataRepository = new LayuiDataRepository();
            return await layuiDataRepository.UpdateSign(arguModifySignColumn.id,arguModifySignColumn.sign);
        }
    }
}
