using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
    public interface IContainer
    {
        TEntity Get<TEntity>();
        bool TryGet<TEntity>(out TEntity entity);
        
        IEnumerable<IBinder> Binders { get; }
        IToBindingDeclaration Bind<T>();

    }
}
