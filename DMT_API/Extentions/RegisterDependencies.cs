using DMT.Domain.Core.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DMTAPI.API.Extentions
{
    public static class RegisterDependencies
    {
        public static void AddAllActivities(this IServiceCollection services, Assembly assembly)
        {
            var activityInterfaceType = typeof(IActivity<,>);
            var activityTypes = assembly.GetTypes()
                .Where(t => t.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == activityInterfaceType)
                );

            foreach (var activityType in activityTypes)
            {
                var interfaceType = activityType.GetInterfaces()
                    .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == activityInterfaceType);

                services.AddScoped(interfaceType, activityType);
            }
        }
    }
}
