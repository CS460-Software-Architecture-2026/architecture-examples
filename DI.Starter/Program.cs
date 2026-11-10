using DI.Core;
using DI.Starter;

var di = new DiContainer();
di.Register<IFirstInterface, FirstImplementation>(Scope.Singleton);
di.Register<ISecondInterface, SecondImplementation>(Scope.Singleton);
di.Register<IFirstInterface, MyImplementation>(Scope.Transient);

var instance = di.Resolve<IFirstInterface>();
var instance2 = di.Resolve<IFirstInterface>();
var instance3 = di.Resolve<ISecondInterface>();

var class_with_dependency_1 = new ClassWithDependency(di.Resolve<IFirstInterface>());

di.Register<ClassWithDependency, ClassWithDependency>(Scope.Transient);

var class_with_dependency_2 = di.Resolve<ClassWithDependency>();

// Task 3: register a pre-created instance (separate container so earlier registrations don't interfere)
Console.WriteLine("\n=== Task 3: pre-created instance ===");
var preCreated = new MyImplementation();
di.Register<IFirstInterface>(preCreated);

var resolved = di.Resolve<IFirstInterface>();
var consumer = di.Resolve<ClassWithDependency>();

Console.WriteLine($"pre-created: {preCreated}");
Console.WriteLine($"direct Resolve returns the pre-created object: {ReferenceEquals(preCreated, resolved)}");
Console.WriteLine($"consumer received the pre-created object:      {ReferenceEquals(preCreated, consumer.Dependency)}");
