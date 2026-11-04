namespace DI.Core;

public class DiContainer : IDiContainer
{
    private readonly Dictionary<Type, Binding> typesToImplementation = new();
    
    private readonly Dictionary<Type, object> typesToObjects = new();

    private readonly List<Type> resolutionChain = new();

    public void Register<TInterface, TImplementation>(Scope scope) 
        where TImplementation : TInterface
    {
        typesToImplementation[typeof(TInterface)] = new Binding()
        {
            InterfaceType = typeof(TInterface),
            ImplementationType = typeof(TImplementation),
            Scope = scope
        };
    }

    public void Register<TInterface>(TInterface instance)
    {
        typesToImplementation[typeof(TInterface)] = new Binding()
        {
            InterfaceType = typeof(TInterface),
            ImplementationType = instance!.GetType(),
            Scope = Scope.Singleton
        };
        typesToObjects[typeof(TInterface)] = instance;
    }

    public object Resolve(Type type)
    {
        var binding = typesToImplementation[type];

        if (binding.Scope == Scope.Singleton && typesToObjects.TryGetValue(type, out var cached))
        {
            return cached;
        }

        if (resolutionChain.Contains(type))
        {
            var chain = resolutionChain.Skip(resolutionChain.IndexOf(type)).Append(type);
            throw new InvalidOperationException(
                $"Circular dependency detected: {string.Join(" -> ", chain.Select(t => t.Name))}");
        }

        var implementationType = binding.ImplementationType;
        var constructor = implementationType.GetConstructors().First();
        var args = new List<object>();

        resolutionChain.Add(type);
        try
        {
            foreach (var parameter in constructor.GetParameters())
            {
                args.Add(Resolve(parameter.ParameterType));
            }
        }
        finally
        {
            resolutionChain.RemoveAt(resolutionChain.Count - 1);
        }

        var instance = constructor.Invoke(args.ToArray());

        if (binding.Scope == Scope.Singleton)
        {
            typesToObjects[type] = instance;
        }

        return instance;
    }

    public T Resolve<T>()
    {
        return (T)Resolve(typeof(T));
    }

    private class Binding
    {
        public required Type InterfaceType { get; init; }

        public required Type ImplementationType { get; init; }

        public required Scope Scope { get; init; }
    }
}
