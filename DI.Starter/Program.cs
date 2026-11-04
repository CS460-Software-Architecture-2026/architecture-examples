using DI.Core;
using DI.Starter;

var di = new DiContainer();
var test = new TestImplementation();
di.Register<ITestInterface>(test);

var resolved = di.Resolve<ITestInterface>();
var resolved2 = di.Resolve<ITestInterface>();

Console.WriteLine(test);
Console.WriteLine(resolved);
Console.WriteLine(resolved2);
