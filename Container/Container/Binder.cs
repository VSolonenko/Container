using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
    public class Binder : IBinder
    {
        private readonly BindingDeclaration _bindingDeclaration;
        public Binder()
        {
            _bindingDeclaration = new BindingDeclaration();
        }
        public IBindingDeclaration BindingDeclaration => _bindingDeclaration;

        public object SingletonObject { get; set; }

        public IToBindingDeclaration Bind<T>()
        {
            _bindingDeclaration.FromType = typeof(T);
            return new ToBindingDeclaration(_bindingDeclaration);
        }
    }
}
