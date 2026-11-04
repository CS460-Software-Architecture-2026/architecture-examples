using DI.Core;
using DI.Starter;

var di = new DiContainer();
di.Register<IFirstInterface, FirstImplementation>(Scope.Singleton);
di.Register<ISecondInterface, SecondImplementation>(Scope.Singleton);
di.Register<ITestImplementation, TestImplementation>(Scope.Singleton);

var test = di.Resolve<ITestImplementation>();
var test_1 = di.Resolve<ITestImplementation>();

Console.WriteLine(test);
Console.WriteLine(test_1);


