using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UPPERIOC.UPPER.IOC.Annaiation;
using UPPERIOC.UPPER.IOC.Center.Interface;
using UPPERIOC.UPPER.IOC.Center.IProvider;

namespace TestDemo.Entity
{
    [IOCObject]
    public class SimpleService
    {
        public string GetData() => "Hello";
    }
    public class IOO : IUPPERMoudle
    {
        public override void AfterCreateInstance(IContainerProvider containerProvider)
        {
            throw new NotImplementedException();
        }

        public override void InitEnd(IContainerProvider containerProvider)
        {
            throw new NotImplementedException();
        }

        public override void IniterAndLoadClass(IContainerProvider containerProvider)
        {
            throw new NotImplementedException();
        }

        public override void PreIniter(IContainerProvider containerProvider)
        {
            throw new NotImplementedException();
        }
    }

    [IOCObject]
    public class ComplexService
    {
        public SimpleService Simple { get; }

        [IOCConstructor]
        public ComplexService(SimpleService simple)
        {
            Simple = simple;
        }
    }

    public interface IInterfaceService
    {
        string Ping();
    }

    [IOCObject]
    public class InterfaceImpl : IInterfaceService
    {
        public string Ping() => "Pong";
    }

    [IOCObject]
    public class PropertyInjectedService
    {
        [IOCPorpeties]
        public SimpleService InjectedProp { get; set; }
    }

}