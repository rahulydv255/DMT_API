using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Domain.Core.Interface
{
    public interface IActivity<in TInput, out TOutput>   
    {
        TOutput Excute(TInput input);
    }

    public interface IActivityAsync<in TInput,  TOutput>
    {
        Task<TOutput> Excute(TInput input);
    }

}
