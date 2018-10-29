using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
    public class ToBindingDeclaration : IToBindingDeclaration
    {
        private readonly BindingDeclaration _bindingDeclaration;

        public ToBindingDeclaration(BindingDeclaration bindingDeclaration)
        {
            _bindingDeclaration = bindingDeclaration;
        }
        public IScopeDeclaration To<TEntity>()
        {
            _bindingDeclaration.ToType = typeof(TEntity);
            return new ScopeDeclaration(_bindingDeclaration);
        }
        public IScopeDeclaration ToConstant<TEntity>(TEntity entity)
        {
            _bindingDeclaration.Constant = entity;
            return To<TEntity>();
        }
        public IScopeDeclaration ToConstant<TEntity>(Func<TEntity> func) => ToConstant(func());
    }
}
