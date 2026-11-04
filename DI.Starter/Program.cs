using DI.Core;
using DI.Starter;

var di = new DiContainer();
di.Register<IFirstInterface, FirstImplementation>(Scope.Singleton);
di.Register<ISecondInterface, SecondImplementation>(Scope.Singleton);
di.Register<IThirdInterface, ThirdImplementation>(Scope.Singleton);

var instance = di.Resolve<IFirstInterface>();
var instance2 = di.Resolve<IFirstInterface>();
var instance3 = di.Resolve<ISecondInterface>();
var instance4 = di.Resolve<IThirdInterface>();

Console.WriteLine(instance);
Console.WriteLine(instance2);
Console.WriteLine(instance3);
Console.WriteLine(instance4);

var di2 = new DiContainer();
di2.Register<IFirstInterface, FirstImplementation>(Scope.Singleton);
di2.Register<IThirdInterface, ThirdImplementation>(Scope.Transient);

var third1 = di2.Resolve<IThirdInterface>();
var third2 = di2.Resolve<IThirdInterface>();

Console.WriteLine(third1);
Console.WriteLine(third2);

var di3 = new DiContainer();
di3.Register<IFirstInterface, FirstImplementation>(Scope.Transient);
di3.Register<IThirdInterface, ThirdImplementation>(Scope.Singleton);

var third3 = di3.Resolve<IThirdInterface>();
var third4 = di3.Resolve<IThirdInterface>();

Console.WriteLine(third3);
Console.WriteLine(third4);
