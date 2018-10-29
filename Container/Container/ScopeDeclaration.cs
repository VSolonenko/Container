using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
    public class ScopeDeclaration : IScopeDeclaration
    {
        private readonly BindingDeclaration _bindingDeclaration;

        public ScopeDeclaration(BindingDeclaration bindingDeclaration)
        {
            _bindingDeclaration = bindingDeclaration;
        }
        public void InSingletoneScope() => _bindingDeclaration.InSingletonScope = true;
    }
}
