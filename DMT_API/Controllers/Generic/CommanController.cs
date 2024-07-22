using DMT.Contracts.Generic;
using DMT.Domain.Core.Interface;
using DMT.Domain.Generic;
using Microsoft.AspNetCore.Mvc;
using Item = DMT.Contracts.Generic.Item;

namespace DMTAPI.API.Controllers.Generic
{
    [ApiController]
    public class CommanController : Controller
    {
        public readonly IActivity<MenuDomainRequest, MenuDomainResponse> _menuGetActivity;
        public CommanController(IActivity<MenuDomainRequest, MenuDomainResponse> menuGetActivity)
        {
            _menuGetActivity = menuGetActivity;
        }

        [HttpPost]
        [Route("api/GetMenu")]
        public MenuConstractResponse GetMenu(MenuContractRequest request)
        {
            var response = new MenuConstractResponse();
            var menuDomainRequest = new MenuDomainRequest();
            var menuDomainResponse = new MenuDomainResponse();
            menuDomainResponse = _menuGetActivity.Excute(menuDomainRequest);

            // Map MenuDomainResponse's MenuItem to MenuConstractResponse's MenuItem
            response.MenuItem = menuDomainResponse.MenuItem.Select(item => new Item
            {
                Id = item.Id,
                Title = item.Title,
                Url = item.Url,
                ParentId = item.ParentId
            }).ToList();



            return response;
        }
    }
}
