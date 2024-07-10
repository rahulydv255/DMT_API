using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Domain.Core.Interface
{
    public interface  IServiceAdapter<in Input, out Toutput>
    {
        Toutput Excute(Input input);
    }
    public interface IServiceAdapterAsync<in TInput, TOutput>
    {
        Task<TOutput> Excute(TInput input);
    }

}
