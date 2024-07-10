using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Domain.Core.Interface
{
    public interface IDatabaseAdapter<in TInput, out TOutput>
    {
        TOutput Execute(TInput input);
    }
}
