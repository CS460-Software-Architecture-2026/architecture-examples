using DI.Core;

var di = new DiContainer();
di.Register<IFirstInterface, FirstImplementation>(Scope.Singleton);
di.Register<ISecondInterface, SecondImplementation>(Scope.Singleton);
di.Register<IThirdInterface, ThirdImplementation>(Scope.Singleton);

var instance = di.Resolve<IFirstInterface>();
var instance2 = di.Resolve<IFirstInterface>();
var instance3 = di.Resolve<ISecondInterface>();
var instance4 = di.Resolve<IThirdInterface>();

Console.WriteLine(instance.ToString());
Console.WriteLine(instance2.ToString());
Console.WriteLine(instance3.ToString());
Console.WriteLine(instance4.ToString());

var transientDi = new DiContainer();
transientDi.Register<IFirstInterface, FirstImplementation>(Scope.Transient);
Console.WriteLine(ReferenceEquals(transientDi.Resolve<IFirstInterface>(), transientDi.Resolve<IFirstInterface>()));

var preCreated = new FirstImplementation();
var instanceDi = new DiContainer();
instanceDi.Register<IFirstInterface>(preCreated);
Console.WriteLine(ReferenceEquals(preCreated, instanceDi.Resolve<IFirstInterface>()));

var circularDi = new DiContainer();
circularDi.Register<ICircularA, CircularA>(Scope.Transient);
circularDi.Register<ICircularB, CircularB>(Scope.Transient);
try
{
    circularDi.Resolve<ICircularA>();
}
catch (InvalidOperationException e)
{
    Console.WriteLine(e.Message);
}
