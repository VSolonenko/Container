using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Container
{
    public class StandardContainer : IContainer
    {
        private readonly List<IBinder> _binders;
        private object Construct(Type type)
        {
            foreach (var constructor in type.GetConstructors())
            {
                var parameters = new List<object>();
                var foo = true;
                foreach (var parameter in constructor.GetParameters())
                {
                    var value = Get(parameter.ParameterType);
                    if (value == null)
                    {
                        foo = false;
                        break;
                    }
                    parameters.Add(value);
                }
                if (foo)
                {
                    return constructor.Invoke(parameters.ToArray());
                }
            }
            return null;
        }

        private object Get(Type type)
        {
            object result = null;
            foreach (var binder in _binders)
            {
                if (binder.BindingDeclaration.FromType.FullName == type.FullName)
                {
                    if (binder.BindingDeclaration.InSingletonScope && binder.SingletonObject != null)
                    {
                        result = binder.SingletonObject;
                    }
                    else
                    {
                        if (binder.BindingDeclaration.TryGetConstant(out var entity))
                        {
                            result = entity;
                        }
                        else
                        {
                            result = Construct(binder.BindingDeclaration.ToType);
                        }
                        if (binder.BindingDeclaration.InSingletonScope)
                        {
                            binder.SingletonObject = result;
                        }
                    }
                }
            }
            return result;
        }

        public StandardContainer():this(new List<IBinder>())
        {

        }
        public StandardContainer(IEnumerable<IBinder> binders)
        {
            _binders = binders.ToList();
        }
        public IEnumerable<IBinder> Binders => _binders;

        //public TEntity Get<TEntity>()
        //{
        //    TEntity result = default(TEntity);
        //    foreach (var binder in _binders)
        //    {
        //        if (binder.BindingDeclaration.FromType.FullName == typeof(TEntity).FullName)
        //        {
        //            if (binder.BindingDeclaration.InSingletonScope && binder.SingletonObject != null)
        //            {
        //                result = (TEntity)binder.SingletonObject;
        //            }
        //            else
        //            {
        //                if (binder.BindingDeclaration.TryGetConstant(out TEntity entity))
        //                {
        //                    result = entity;
        //                }
        //                else
        //                {
        //                    var foo = Construct(binder.BindingDeclaration.ToType);
        //                    result = foo != null ? (TEntity)foo : default(TEntity);
        //                }
        //                if (binder.BindingDeclaration.InSingletonScope)
        //                {
        //                    binder.SingletonObject = result;
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}
        
        public bool TryGet<TEntity>(out TEntity entity) => (entity = Get<TEntity>()) != null ? true : false;
        public IToBindingDeclaration Bind<T>()
        {
            var binder = new Binder();
            _binders.Add(binder);
            return binder.Bind<T>();
        }

        public TEntity Get<TEntity>() => (TEntity)Get(typeof(TEntity));
    }
}
