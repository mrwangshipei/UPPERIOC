using Xunit;
using UPPERIOC.UPPER.IOC.Center.IProvider;
using TestDemo.Entity;
using UPPERIOC.UPPER.IOC.DefaultProvider;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System;

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
    [Fact]
    public void Concurrent_Resolve_Should_Be_Thread_Safe()
    {
        _container.Rigister<SimpleService>(false); // 非单例，避免因共享导致误判

        var exceptions = new ConcurrentQueue<Exception>();
        var results = new ConcurrentBag<SimpleService>();

        Parallel.For(0, 1000, i =>
        {
            try
            {
                var instance = _container.GetInstance<SimpleService>();
                if (instance == null || instance.GetData() != "Hello")
                {
                    exceptions.Enqueue(new Exception("Resolved instance invalid"));
                }
                results.Add(instance);
            }
            catch (Exception ex)
            {
                exceptions.Enqueue(ex);
            }
        });

        Assert.Empty(exceptions); // 不应有异常
        Assert.Equal(1000, results.Count); // 所有实例都应返回
    }

    [Fact]
    public void Concurrent_Register_And_Resolve_Should_Not_Throw()
    {
        var exceptions = new ConcurrentQueue<Exception>();

        Parallel.For(0, 100, i =>
        {
            try
            {
                _container.Rigister<SimpleService>(false);
                var resolved = _container.GetInstance<SimpleService>();
                if (resolved == null || resolved.GetData() != "Hello")
                {
                    exceptions.Enqueue(new Exception("Invalid resolution"));
                }
            }
            catch (Exception ex)
            {
                exceptions.Enqueue(ex);
            }
        });

        Assert.Empty(exceptions); // 并发注册和解析不应抛出异常
    }
    [Fact]
    public void Concurrent_Resolve_ComplexService_Should_Be_Thread_Safe()
    {
        _container.Rigister<SimpleService>();
        _container.Rigister<ComplexService>();

        var exceptions = new ConcurrentQueue<Exception>();
        var results = new ConcurrentBag<ComplexService>();

        Parallel.For(0, 1000, i =>
        {
            try
            {
                var instance = _container.GetInstance<ComplexService>();
                if (instance == null || instance.Simple == null || instance.Simple.GetData() != "Hello")
                {
                    exceptions.Enqueue(new Exception("Constructor injection failed"));
                }
                results.Add(instance);
            }
            catch (Exception ex)
            {
                exceptions.Enqueue(ex);
            }
        });

        Assert.Empty(exceptions);
        Assert.Equal(1000, results.Count);
    }
    [Fact]
    public void Concurrent_Resolve_PropertyInjectedService_Should_Be_Thread_Safe()
    {
        _container.Rigister<SimpleService>();
        _container.Rigister<PropertyInjectedService>();

        var exceptions = new ConcurrentQueue<Exception>();
        var results = new ConcurrentBag<PropertyInjectedService>();

        Parallel.For(0, 1000, i =>
        {
            try
            {
                var instance = _container.GetInstance<PropertyInjectedService>();
                if (instance == null || instance.InjectedProp == null || instance.InjectedProp.GetData() != "Hello")
                {
                    exceptions.Enqueue(new Exception("Property injection failed"));
                }
                results.Add(instance);
            }
            catch (Exception ex)
            {
                exceptions.Enqueue(ex);
            }
        });

        Assert.Empty(exceptions);
        Assert.Equal(1000, results.Count);
    }

}
