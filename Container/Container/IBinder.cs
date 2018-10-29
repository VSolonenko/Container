namespace Container
{
    public interface IBinder
    {
        IToBindingDeclaration Bind<T>();
        IBindingDeclaration BindingDeclaration { get; }
        object SingletonObject { get; set; }
    }
}