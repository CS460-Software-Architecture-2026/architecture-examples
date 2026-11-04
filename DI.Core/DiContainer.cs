namespace DI.Core;

public class DiContainer : IDiContainer
{
    private readonly Dictionary<Type, Binding> typesToImplementation = new();
    private readonly Dictionary<Type, object> typesToObjects = new();

    public void Register<TInterface, TImplementation>(Scope scope)
        where TImplementation : TInterface
    {
        var type = typeof(TInterface);
        typesToImplementation[type] = new Binding
        {
            ImplementationType = typeof(TImplementation),
            Scope = scope
        };
        typesToObjects.Remove(type);
    }

    public void Register<TInterface>(TInterface instance) where TInterface : class
    {
        ArgumentNullException.ThrowIfNull(instance);
        var type = typeof(TInterface);
        typesToImplementation.Remove(type);
        typesToObjects[type] = instance;
    }

    public object Resolve(Type type)
    {
        if (typesToObjects.TryGetValue(type, out var existing))
            return existing;

        if (!typesToImplementation.TryGetValue(type, out var binding))
            throw new InvalidOperationException($"Type {type.Name} is not registered.");

        var constructor = binding.ImplementationType.GetConstructors().FirstOrDefault()
            ?? throw new InvalidOperationException($"No public constructor for {binding.ImplementationType.Name}.");

        var args = new List<object>();
        foreach (var parameter in constructor.GetParameters())
            args.Add(Resolve(parameter.ParameterType));

        var instance = constructor.Invoke(args.ToArray());
        if (binding.Scope == Scope.Singleton)
            typesToObjects[type] = instance;

        return instance;
    }

    public T Resolve<T>()
    {
        return (T)Resolve(typeof(T));
    }

    private class Binding
    {
        public required Type ImplementationType { get; init; }
        public required Scope Scope { get; init; }
    }
}
