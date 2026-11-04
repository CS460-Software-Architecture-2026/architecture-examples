using DI.Core;

// var di = new DiContainer();
// di.Register<IFirstInterface, FirstImplementation>(Scope.Singleton);
// di.Register<ISecondInterface, SecondImplementation>(Scope.Singleton);
// di.Register<IThirdInterface, ThirdImplementation>(Scope.Transient);
//
// var instance = di.Resolve<IFirstInterface>();
// var instance2 = di.Resolve<IFirstInterface>();
// var instance3 = di.Resolve<ISecondInterface>();
// var instance4 = di.Resolve<IThirdInterface>();
//
// Console.WriteLine($"{instance} : {instance2} : {instance3} : {instance4}");


var di = new DiContainer();
var firstImplementation = new FirstImplementation();
di.Register<IFirstInterface>(firstImplementation, Scope.Singleton);

var instance = di.Resolve<IFirstInterface>();

Console.WriteLine($"{firstImplementation} : {instance}");