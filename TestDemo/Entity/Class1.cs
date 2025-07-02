using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UPPERIOC.UPPER.IOC.Annaiation;

namespace TestDemo.Entity
{
    [IOCObject]
    public class SimpleService
    {
        public string GetData() => "Hello";
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