using DI.Core;
using DI.Starter;

var di = new DiContainer();
// di.Register<IFirstInterface, FirstImplementation>(Scope.Singleton);
// di.Register<ISecondInterface, SecondImplementation>(Scope.Singleton);
// di.Register<IThirdInterface, ThirdImplementation>(Scope.Singleton);

// di.Register<IThirdInterface, ThirdImplementation>(Scope.Transient);

// var instance = di.Resolve<IFirstInterface>();
// var instance2 = di.Resolve<IFirstInterface>();
// var instance3 = di.Resolve<ISecondInterface>();
// var instance4 = di.Resolve<IThirdInterface>();
// Console.WriteLine(instance);
// Console.WriteLine(instance2);
// Console.WriteLine(instance3);
// Console.WriteLine(instance4);

//transient depends on a singleton
// var instance = di.Resolve<IThirdInterface>();
// var instance2 = di.Resolve<IThirdInterface>();

// Console.WriteLine(ReferenceEquals(instance, instance2));

// singleton depends on a transient
// ThirdImplementation (Singleton) -> SecondImplementation (Transient)
di.Register<IThirdInterface, ThirdImplementation>(Scope.Singleton);
di.Register<ISecondInterface, SecondImplementation>(Scope.Transient);

var singleton1 = di.Resolve<IThirdInterface>();
var singleton2 = di.Resolve<IThirdInterface>();
var transient1 = di.Resolve<ISecondInterface>();
var transient2 = di.Resolve<ISecondInterface>();

Console.WriteLine($"{ReferenceEquals(singleton1, singleton2)}");
Console.WriteLine($"{ReferenceEquals(singleton1.Dependency, singleton2.Dependency)}");
Console.WriteLine($"{ReferenceEquals(singleton1.Dependency, transient1)}");
Console.WriteLine($"{ReferenceEquals(transient1, transient2)}");

