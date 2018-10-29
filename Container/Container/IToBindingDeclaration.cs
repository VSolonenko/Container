using System;

namespace Container
{
    public interface IToBindingDeclaration
    {
        IScopeDeclaration To<TEntity>();
        IScopeDeclaration ToConstant<TEntity>(TEntity entity);
        IScopeDeclaration ToConstant<TEntity>(Func<TEntity> func);
    }
}