using System;
using System.Collections.Generic;
using System.Text;

namespace IoC.AspNetCore.Common
{
    public interface IHiyServiceCollection
    {
        void AddScope(Type serviceType, Type implementationType);

        T GetService<T>();
    }
}
