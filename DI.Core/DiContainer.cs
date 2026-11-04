namespace DI.Core;

public class DiContainer : IDiContainer
{
    // Правила: "для інтерфейсу X створюй клас Y з таким-то Scope"
    private readonly Dictionary<Type, Binding> typesToImplementation = new();

    // Вже готові об'єкти: створені singleton-и та зареєстровані вручну інстанси
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

        // Перереєстрація замінює попередній готовий об'єкт, якщо він був
        typesToObjects.Remove(typeof(TInterface));
    }

    // Завдання 3: реєстрація вже створеного об'єкта.
    // Контейнер нічого не конструює, а просто завжди віддає саме цей instance.
    public void Register<TInterface>(TInterface instance)
    {
        ArgumentNullException.ThrowIfNull(instance);

        typesToObjects[typeof(TInterface)] = instance;

        // Правило для цього типу більше не потрібне — є готовий об'єкт
        typesToImplementation.Remove(typeof(TInterface));
    }

    public object Resolve(Type type)
    {
        // 1. Спочатку шукаємо готовий об'єкт (singleton або instance з Register(instance))
        if (typesToObjects.TryGetValue(type, out var existing))
        {
            return existing;
        }

        // 2. Готового немає — шукаємо правило, як створити
        if (!typesToImplementation.TryGetValue(type, out var binding))
        {
            throw new InvalidOperationException($"Type '{type.Name}' is not registered in the container.");
        }

        var implementationType = binding.ImplementationType;
        var constructor = implementationType.GetConstructors().First();
        var args = new List<object>();
        foreach (var parameter in constructor.GetParameters())
        {
            args.Add(Resolve(parameter.ParameterType));
        }

        var instance = constructor.Invoke(args.ToArray());

        // Завдання 2: кешуємо ТІЛЬКИ singleton. Transient не зберігаємо,
        // тому наступний Resolve створить новий об'єкт.
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
