namespace DI.Core;

public class DiContainer : IDiContainer
{
    private readonly Dictionary<Type, Binding> typesToImplementation = new();
    
    private readonly Dictionary<Type, object> typesToObjects = new();

    public void Register<TInterface, TImplementation>(Scope scope) 
        where TImplementation : TInterface
    {
        typesToImplementation[typeof(TInterface)] = new Binding()
        {
            InterfaceType = typeof(TInterface),
            ImplementationType = typeof(TImplementation),
            Scope = scope
        };
        typesToObjects.Remove(typeof(TInterface));
    }

    public void Register<TInterface>(TInterface instance) where TInterface : notnull
    {
        typesToObjects[typeof(TInterface)] = instance;
    }

    public object Resolve(Type type)
    {
        return Resolve(type, new List<Type>());
    }

    private object Resolve(Type type, List<Type> dependencyChain)
    {
        if (typesToObjects.TryGetValue(type, out var result))
        {
            return result;
        }

        if (dependencyChain.Contains(type))
        {
            var chain = string.Join(" -> ", dependencyChain.Append(type).Select(t => t.Name));
            throw new InvalidOperationException($"Circular dependency: {chain}");
        }

        var binding = typesToImplementation[type];
        dependencyChain.Add(type);
        
        var implementationType = binding.ImplementationType;
        var constructor = implementationType.GetConstructors().First();
        var args = new List<object>();
        foreach (var parameter in constructor.GetParameters())
        {
            args.Add(Resolve(parameter.ParameterType, dependencyChain));
        }

        var instance = constructor.Invoke(args.ToArray());
        dependencyChain.RemoveAt(dependencyChain.Count - 1);
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
