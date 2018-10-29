using System;

namespace Container
{
    public interface IBindingDeclaration
    {
        Type FromType { get; }
        Type ToType { get; }
        bool InSingletonScope { get; }
        bool TryGetConstant<T>(out T entity);
        bool TryGetConstant(out object entity);
    }
}