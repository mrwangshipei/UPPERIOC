<div align="center">

![logo](asset/UPPERIOC.png)

</div>

# UPPERIOC

<p align="center">
  <a href="https://github.com/mrwangshipei/UPPERIOC">
    <img src="https://badgen.net/badge/Github/mrwangshipei/21D789?icon=github">
  </a>
  <img src="https://img.shields.io/badge/NetStandard-2.0-blue">
  <a href="https://github.com/mrwangshipei/UPPERIOC/blob/master/LICENSE">
    <img alt="GitHub" src="https://img.shields.io/github/license/mrwangshipei/UPPERIOC?style=flat-square">
  </a>
  <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/mrwangshipei/UPPERIOC?style=flat-square">
  <img alt="GitHub Repo stars" src="https://img.shields.io/github/stars/mrwangshipei/UPPERIOC?style=social">
</p>

---

## 🔰 项目简介

`UPPERIOC` 是为 WinForm 应用打造的 IoC 容器与模块框架，专注于快速构建标准化、可维护的桌面系统。

- 支持模块化组织和自动注入
- 完整生命周期管理，行为可控
- 提供全局事件监听机制
- 并发安全，运行期无线程冲突
- 单元测试覆盖齐全，流程可靠

适合个人开发、小型工具系统、快速原型。

---

## 🚀 快速上手

```csharp
static void Main() {
    UPPERIOCApplication.RunInstance(md =>
    {
        md.UPPERFileModelMoudle(new FileModle());
        md.UPPERMLockMoudle(new MLock());
        md.UPPERLogFileMoudle(new FIleLogConfig());
    });
    Application.Run(new Form1());
}
```

---

## 🧱 模块注册与生命周期

模块实现 `IUPPERModule` 接口系列，即可响应容器初始化流程：

```csharp
public class MyModule : IUPPERModule,
    IModulePreInitialization,
    IModuleInitialization,
    IModulePostConstruction,
    IModulePostInitialization,
    IModulePreDestruction
{
    public override Type[] Dependencies => null;

    public void OnPreInitialize(IContainerProvider p) => Log("PreInit");
    public void OnInitialize(IContainerProvider p) => Log("Init");
    public void OnPostConstruct(IContainerProvider p) => Log("PostConstruct");
    public void OnPostInitialize(IContainerProvider p) => Log("PostInit");
    public void OnPreDestroy(IContainerProvider p) => Log("Destroy");

    void Log(string stage) => Console.WriteLine(stage);
}
```

注册方式：

```csharp
UPPERIOCApplication.RunInstance(md => {
    md.AddModule<MyModule>();
});
```

模块执行顺序严格保证：  
**依赖先于本模块初始化，生命周期流程按规范推进。**

---

## 📡 容器全局事件监听（推荐使用）

若你需要监听容器生命周期的各阶段行为，可通过事件系统实现。监听器实现如下：

```csharp
public class FullLifecycleListener :
    IUPPERApplicationListener<ApplicationPreInitializationEvent>,
    IUPPERApplicationListener<ApplicationModuleInitializedEvent>,
    IUPPERApplicationListener<ApplicationInstanceCreatedEvent>,
    IUPPERApplicationListener<ApplicationInitEndEvent>,
    IUPPERApplicationListener<ApplicationStoppingEvent>,
    IUPPERApplicationListener<ApplicationStoppedEvent>
{
    private readonly List<string> _eventLog;
    public FullLifecycleListener(List<string> log) => _eventLog = log;

    public void OnEvent(ApplicationPreInitializationEvent e) => _eventLog.Add("PreInit");
    public void OnEvent(ApplicationModuleInitializedEvent e) => _eventLog.Add("ModuleInit");
    public void OnEvent(ApplicationInstanceCreatedEvent e) => _eventLog.Add("InstanceCreated");
    public void OnEvent(ApplicationInitEndEvent e) => _eventLog.Add("InitEnd");
    public void OnEvent(ApplicationStoppingEvent e) => _eventLog.Add("Stopping");
    public void OnEvent(ApplicationStoppedEvent e) => _eventLog.Add("Stopped");
}
```

注册监听器：

```csharp
UPPERIOCApplication.RunInstance(md => { }, e => {
    e.RegisterListener<ApplicationPreInitializationEvent>(
        new FullLifecycleListener(_eventLog)
    );
});
```

📌 **提示**：监听器注册时机不受限制，**生命周期尚未开始时注册也有效**，可在程序任何位置动态添加。

在应用运行中注册监听器(此方式必须在容器初始化完成后才可用，否则U.E...将抛出NPE):

```csharp
    U.E.RegisterListener<ApplicationPreInitializationEvent>(
        new FullLifecycleListener(_eventLog)
    );
```

---

## ✨ 功能一览

- ✅ IoC 容器（注解式注入）
- ✅ 模块化注册与隔离
- ✅ 生命周期控制
- ✅ 日志系统（默认文件日志）
- ✅ 消息通信（发布/订阅）
- ✅ 配置建模（序列化）
- ✅ 权限管理（基础版）
- ✅ 翻译模块（可接第三方 API）
- ✅ 防多开锁定（MLock）

---

## 📦 包下载

| 包名      | NuGet Stable | NuGet PreRelease | 下载量 | MyGet |
|-----------|---------------|------------------|--------|--------|
| [UPPERIOC](https://www.nuget.org/packages/UPPERIOC/)  | ![Stable](https://img.shields.io/nuget/v/UPPERIOC.svg) | ![Pre](https://img.shields.io/nuget/vpre/UPPERIOC.svg) | ![Downloads](https://img.shields.io/nuget/dt/UPPERIOC.svg) | ![MyGet](https://img.shields.io/myget/UPPERIOC/vpre/UPPERIOC.svg) |

---

## 🧯 常见问题

- **我开发的模块别人难道要记住模块名称才能注册吗？**  
  这个问题现在的解决方案是通过在命名空间 **UPPERIOC.UPPER.IOC.Center.Configuation** 下写扩展方法，编译器就会自动在ModuleConfiguation点的时候带出你的模块，只需要引用了你的Nuget包，开发方式如下
```
namespace UPPERIOC.UPPER.IOC.Center.Configuation
{
    public static class UPPERMoudleManager
    {
        public static void UPPERIOCMoudle(this ModuleConfiguaion md)
        {
            md.AddModule<UPPERIOCModule>();
        }
    }
}
```


- **请问支持xml配置吗，因为这样可能会比较方便修改？**  
  暂时不支持，但是你可以使用UModel模块在实现配置接口的时候实现IModel，这样容器在加载配置类的时候就会从你的xml文件中加载，具体方法后续补充。

---

## 💬 联系方式

- QQ 群：816781059  
- QQ：3644005356  
- GitHub：[mrwangshipei/UPPERIOC](https://github.com/mrwangshipei/UPPERIOC)

---

如果你觉得这个项目对你有帮助，欢迎 Star 🌟 支持。
