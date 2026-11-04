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
instance4.SomeMethod();

di.Register<IFirstInterface, FirstImplementation>(Scope.Singleton);
di.Register<ISecondInterface, SecondImplementation>(Scope.Transient);

var a = di.Resolve<ISecondInterface>();
var b = di.Resolve<ISecondInterface>();
Console.WriteLine(ReferenceEquals(a, b));                 
Console.WriteLine(ReferenceEquals(a.First, b.First));

di.Register<IFirstInterface, FirstImplementation>(Scope.Transient);
di.Register<ISecondInterface, SecondImplementation>(Scope.Singleton);

var a1 = di.Resolve<ISecondInterface>();
var b1 = di.Resolve<ISecondInterface>();
Console.WriteLine(ReferenceEquals(a1, b1));  

var myFirst = new FirstImplementation();
di.Register<IFirstInterface>(myFirst);
di.Register<ISecondInterface, SecondImplementation>(Scope.Transient);

var second = di.Resolve<ISecondInterface>();

Console.WriteLine(ReferenceEquals(di.Resolve<IFirstInterface>(), myFirst));
Console.WriteLine(ReferenceEquals(((SecondImplementation)second).First, myFirst));