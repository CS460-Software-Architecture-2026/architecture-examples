namespace DI.Core;

public interface IDiContainer
{
    void Register<TInterface, TImplementation>(Scope scope) 
        where TImplementation : TInterface;

    T Resolve<T>();
    
    void Register<TInterface>(TInterface instance);
}

public enum Scope
{
    Singleton, Transient
}