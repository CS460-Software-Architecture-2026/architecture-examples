using DI.Core;
using DI.Starter;

var di = new DiContainer();
di.Register<IFirstInterface, FirstImplementation>(Scope.Singleton);
di.Register<ITestInterface, TestInterface>(Scope.Transient);

var test = di.Resolve<ITestInterface>();
var test_1 = di.Resolve<ITestInterface>();

Console.WriteLine(test);
Console.WriteLine(test_1);

// Prediction: if Singleton depends on transient - no problem,
// but it will have the same instance of the transit (so it becomes singleton)
// check
var instance = di.Resolve<IFirstInterface>();
var instance1 = di.Resolve<IFirstInterface>();

Console.WriteLine(instance);
Console.WriteLine(instance1);

// result: as predicted - runned fine, same instance of transient