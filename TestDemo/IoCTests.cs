using Xunit;
using UPPERIOC2.UPPER.UIOC.DefaultProvider;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using TestDemo.Entity;

public class IoCTests
{
    private readonly UPPERDefaultProvider _container;

    public IoCTests()
    {
        _container = new UPPERDefaultProvider();
    }

    [Fact]
    public void Register_And_Resolve_SimpleService()
    {
        var obj = _container.Rigister<SimpleService>();
        Assert.NotNull(obj);
        var resolved = _container.GetInstance<SimpleService>();
        Assert.NotNull(resolved);
        Assert.Equal("Hello", resolved.GetData());
    }

    [Fact]
    public void Register_And_Resolve_ComplexService_With_Dependency()
    {
        _container.Rigister<SimpleService>();
        var obj = _container.Rigister<ComplexService>();

        Assert.NotNull(obj);
        Assert.NotNull(obj.Simple);
        Assert.Equal("Hello", obj.Simple.GetData());
    }

    [Fact]
    public void Register_With_Name_And_Resolve_By_Name()
    {
        var name = "MySimple";
        var reg = _container.Rigister<SimpleService>(name);

        var resolved = _container.GetInstance<SimpleService>(name);
        Assert.NotNull(resolved);
        Assert.Equal("Hello", resolved.GetData());
    }

    [Fact]
    public void Register_Interface_And_Resolve_Concrete_Implementation()
    {
        _container.Rigister<InterfaceImpl>();
        var service = _container.GetInstanceAndSub<IInterfaceService>();
        Assert.NotNull(service);
        Assert.Equal("Pong", service.Ping());
    }

    [Fact]
    public void Register_Multiple_Instances_Should_Be_Different_When_Single_False()
    {
        var obj1 = _container.Rigister<SimpleService>( false);
        var obj2 = _container.GetInstance(typeof(SimpleService));
        Assert.NotNull(obj1);
        Assert.NotNull(obj2);
        Assert.NotSame(obj1, obj2);
    }

    [Fact]
    public void Property_Injection_Should_Work()
    {
        _container.Rigister<SimpleService>();
        var result = _container.Rigister<PropertyInjectedService>();

        Assert.NotNull(result);
        Assert.NotNull(result.InjectedProp);
        Assert.Equal("Hello", result.InjectedProp.GetData());
    }
}
