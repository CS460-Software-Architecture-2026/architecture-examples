using DI.Core;

var di = new DiContainer();
di.Register<IFirstInterface, FirstImplementation>(Scope.Transient);
di.Register<ISecondInterface, SecondImplementation>(Scope.Transient);
di.Register<IThirdInterface, ThirdImplementation>(Scope.Transient);
di.Register<IFourthInterface, FourthImplementation>(Scope.Transient);


var instance = di.Resolve<IFirstInterface>();
var instance2 = di.Resolve<IFirstInterface>();
var instance3 = di.Resolve<ISecondInterface>();
var instance4 = di.Resolve<IFourthInterface>();
var instance5 = di.Resolve<IThirdInterface>();

Console.WriteLine($"First #1:  {instance}");
Console.WriteLine($"First #2:  {instance2}");
Console.WriteLine($"Second:    {instance3}");
Console.WriteLine($"Fourth:    {instance4}");
Console.WriteLine($"Third:     {instance5}");
