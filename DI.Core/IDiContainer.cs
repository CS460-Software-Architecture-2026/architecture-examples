namespace DI.Core;

public interface IDiContainer
{
    void Register<TInterface, TImplementation>(Scope scope) 
        where TImplementation : TInterface;

    void Register<TInterface>(TInterface instance) where TInterface : notnull;

    T Resolve<T>();
}

public enum Scope
{
    Singleton, Transient
}
