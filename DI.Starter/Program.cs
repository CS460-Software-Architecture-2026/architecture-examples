using DI.Core;

static void Check(bool condition)
{
    if (!condition)
        throw new Exception("DI check failed");
}

var di = new DiContainer();
di.Register<IFirstInterface, FirstImplementation>(Scope.Singleton);
di.Register<ISecondInterface, SecondImplementation>(Scope.Transient);
di.Register<IThirdInterface, ThirdImplementation>(Scope.Singleton);
di.Register<ThirdConsumer, ThirdConsumer>(Scope.Transient);

var consumer = di.Resolve<ThirdConsumer>();
var third = di.Resolve<IThirdInterface>();
Check(consumer.Third is ThirdImplementation && ReferenceEquals(consumer.Third, third));

var second1 = (SecondImplementation)di.Resolve<ISecondInterface>();
var second2 = (SecondImplementation)di.Resolve<ISecondInterface>();
Check(!ReferenceEquals(second1, second2));
Check(ReferenceEquals(second1.First, second2.First));
Check(ReferenceEquals(third, di.Resolve<IThirdInterface>()));
Check(ReferenceEquals(third.Second, di.Resolve<IThirdInterface>().Second));

var ready = new FirstImplementation();
var instanceContainer = new DiContainer();
instanceContainer.Register<IFirstInterface>(ready);
instanceContainer.Register<ISecondInterface, SecondImplementation>(Scope.Transient);
var injected = (SecondImplementation)instanceContainer.Resolve<ISecondInterface>();
Check(ReferenceEquals(ready, instanceContainer.Resolve<IFirstInterface>()));
Check(ReferenceEquals(ready, injected.First));
