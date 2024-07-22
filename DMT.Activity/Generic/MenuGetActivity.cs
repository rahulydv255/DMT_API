using DMt.DataAccess.Generic;
using DMT.Domain.Core.Interface;
using DMT.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Activity.Generic
{
    public class MenuGetActivity : IActivity<MenuDomainRequest, MenuDomainResponse>
    {
        public readonly IDatabaseAdapter<MenuDomainRequest, MenuDomainResponse> _menuGetAdapter;
        public MenuGetActivity(IDatabaseAdapter<MenuDomainRequest, MenuDomainResponse> menuGetAdapter)
        {
            _menuGetAdapter= menuGetAdapter;
        }
        public MenuDomainResponse Excute(MenuDomainRequest input)
        {
            var response = new MenuDomainResponse();
            response= _menuGetAdapter.Execute(input);
            return response;
        }
    }
}
