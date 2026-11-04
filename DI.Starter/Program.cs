using DI.Core;
using DI.Starter;


var di = new DiContainer();
di.Register<IFirstInterface, FirstImplementation>(Scope.Transient);
di.Register<ISecondInterface, SecondImplementation>(Scope.Singleton);
di.Register<ISomeClass, SomeClass>(Scope.Singleton);

// var second = di.Resolve<ISecondInterface>();
// second.RunSomething();

var instance = di.Resolve<ISecondInterface>();
var instance2 = di.Resolve<ISecondInterface>();
var instance3 = di.Resolve<IFirstInterface>();

Console.WriteLine($"{instance}\n{instance2}\n{instance3}");


