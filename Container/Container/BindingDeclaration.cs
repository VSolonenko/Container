using System;
using System.Collections.Generic;
using System.Text;

namespace Container
{
    public class BindingDeclaration : IBindingDeclaration
    {
        public Type FromType { get; set; }

        public Type ToType { get; set; }

        public bool InSingletonScope { get; set; }
        public object Constant { get; set; }
        public bool TryGetConstant<T>(out T entity)
        {
            entity = default(T);
            var result = false;
            if (Constant != null && Constant is T)
            {
                entity = (T)Constant;
                result = true;
            }
            return result;
        }

        public bool TryGetConstant(out object entity)
        {
            entity = Constant;
            return entity != null;
        }
    }
}
