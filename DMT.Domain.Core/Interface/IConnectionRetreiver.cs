using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Domain.Core.Interface
{
    public interface IConnectionRetreiver
    {
        IDbConnection GetDbConnection();
    }
}
