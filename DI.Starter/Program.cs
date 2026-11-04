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

Console.WriteLine(instance3.ToString());
Console.WriteLine(instance4.ToString());

var myFirst = new FirstImplementation();
di.Register<IFirstInterface>(myFirst);
var resolved = di.Resolve<IFirstInterface>();
Console.WriteLine(ReferenceEquals(myFirst, resolved));


