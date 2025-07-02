
<div align="center">

![logo](asset/UPPERIOC.png)

</div>

<h1 align="center">UPPERIOC</h1>

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

## 📦 包管理

MyGet Pre-release feed: [https://www.nuget.org/packages/UPPERIOC/](https://www.nuget.org/packages/UPPERIOC/)

| Package                                              | NuGet Stable                                                 | NuGet Pre-release                                            | Downloads                                                        | MyGet                                                             |
| ---------------------------------------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ | ---------------------------------------------------------------- | ----------------------------------------------------------------- |
| [UPPERIOC](https://www.nuget.org/packages/UPPERIOC/) | ![NuGet Stable](https://img.shields.io/nuget/v/UPPERIOC.svg) | ![NuGet Pre](https://img.shields.io/nuget/vpre/UPPERIOC.svg) | ![NuGet Downloads](https://img.shields.io/nuget/dt/UPPERIOC.svg) | ![MyGet](https://img.shields.io/myget/UPPERIOC/vpre/UPPERIOC.svg) |

---

## 🔰 项目说明

UPPERIOC 是一个为 WinForm 应用设计的 IOC 容器和插件集合框架，旨在帮助开发者快速搭建标准化、模块化的单体应用程序。项目完全开源并长期维护。

**适合个人学习、小型项目、原型系统等快速开发场景。**

> ⚠️ 注意：未针对高性能或大规模项目优化，使用即代表理解并接受可能的风险。

---

## ✨ 功能概览

* IOC 容器 + 注解式注入
* 日志系统（默认实现文件日志）
* 消息通信模块（Sendor）
* 文件配置模型系统（Model）
* 工具集（Util）
* 应用加锁（MLock）
* 权限系统（SimplePremission）
* 翻译模块（Translate）

---

## 🚀 快速入门

```csharp
static void main() {
    var config = new UPPERIOC.UPPER.IOC.Center.Configuation.MoudleConfiguaion();
    config.AddMoudle<UPPERIOCMoudle>();
    config.AddMoudle<UPPERLogFileMoudle>();
    config.AddMoudle<UPPERSendorMoudle>();
    config.AddMoudle<UPPERMLockMoudle>();
    config.AddMoudle<UPPERPremissionMoudle>();
    config.AddMoudle<UPPERFileModelMoudle>();
    config.AddMoudle<UPPERErrorMoudle>();
    config.AddMoudle<UPPERTranslateMoudle>();
    config.SetProvider<UPPERDefaultProvider>();
    UPPERIOCApplication.RunInstance(config);
    Application.Run(new Form1());
}
```

---

## 🧩 模块详解

### Sendor

```csharp
SendorCenter.Register<object>(x => {
    LogCenter.Log(x.ToString());
});

SendorCenter.Publish<object>("HelloWorld");
```

### Log

```csharp
config.AddMoudle<UPPERLogFileMoudle>();

internal class FCTUFileConfiguation : IFileLogConfiguation {
    public string DirectoryName => "FCTlog";
    public string DefaultExt => ".log";
    public List<LogType> WhichTypePrint => new() { LogType.Debug, LogType.Warn, LogType.Info, LogType.Error };
    public string FileNameTimeFormat => "日志yyyyMMdd";
    public int HowManyHourSave => 48;
    public bool PrintMs => true;
}

config._containerProvider.Rigister<FCTUFileConfiguation>(new FCTUFileConfiguation());
LogCenter.Log("Hello");
```

### Model

```csharp
config.AddMoudle<UPPERFileModelMoudle>();

internal class UFileModelConfigration : IUFileModelConfiguation {
    public string SaveModelPath => "conf";
}

config._containerProvider.Rigister<UFileModelConfigration>(new UFileModelConfigration());

F.I.SaveModel(new T());
var t = F.I.GetModel(new T());
```

### IOCObject 注入

```csharp
[IOCObject]
public class VerContent {
    public string Up;
    public string Ver;
    public string Content;
}

config.AddMoudle<UPPERIOCMoudle>();
U.C.GetInstance<VerContent>();
```

### MLock

```csharp
public class MLockConfiguation {
    public virtual string Solt { get; set; }
    public virtual string Listenaddr { get; set; }
    public virtual string LockName { get; set; }
    public virtual void Noregister() {
        Console.Write("没有注册");
        Environment.Exit(0);
    }
}

config.AddMoudle<UPPERMLockMoudle>();
config._containerProvider.Rigister<ILockConfiguation>();
```

### Translate

```csharp
public interface ITranslateConfig {
    string APPKey { get; }
    string APPSeret { get; }
    string FromLanguage { get; }
    string ToLanguage { get; }
}

config.AddMoudle<UPPERTranslateMoudle>();
TranslateCenter.Instance.SetRootWindows(this);
```

---

## 🏗️ 架构概览

* `UPPERIOC.UPPERApplication`：核心入口
* `*.Moudle`：可插拔模块集合
* `*.Center`：使用者调用接口
* `*.IConfigration`：配置接口
* `*.IModel`：数据模型接口

---

## 🧯 常见问题

### IOCObject 失效

> 错误提示：CSC warning CS9057 编译器版本不兼容

**解决方法**：更新 `Microsoft.CodeAnalysis.CSharp` 到 `4.10.0+`

### Configuation 找不到

> 手动注入或开启默认容器 Provider

### WinForm 设计器类无法显示

> **提示**：文件中的类不能进行设计，请确保已生成所有项目

**解决方法**：生成项目解决

---

## 💬 联系我

如对跨平台移植、性能增强等有兴趣，欢迎私信参与！

---

如果你觉得这个项目对你有帮助，欢迎 Star 🌟 一下！
