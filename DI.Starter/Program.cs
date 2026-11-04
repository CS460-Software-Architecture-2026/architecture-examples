using DI.Core;
using DI.Starter;

var di = new DiContainer();
// di.Register<IFirstInterface, FirstImplementation>(Scope.Singleton);
di.Register<IFirstInterface, FirstImplementation>(Scope.Transient);
di.Register<ISecondInterface, SecondImplementation>(Scope.Singleton);
// di.Register<ISecondInterface, SecondImplementation>(Scope.Transient);
di.Register<IThirdInterface, ThirdImplementation>(Scope.Singleton);

var instance = di.Resolve<IFirstInterface>();
var instance2 = di.Resolve<IFirstInterface>();
var instance3 = di.Resolve<ISecondInterface>();
var instance4 = di.Resolve<IThirdInterface>();
var second1 = di.Resolve<ISecondInterface>();
var second2 = di.Resolve<ISecondInterface>();

Console.WriteLine(second1);
Console.WriteLine(second2);
Console.WriteLine(instance);
Console.WriteLine(instance2);
Console.WriteLine(instance3);
Console.WriteLine(instance4);
