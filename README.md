<div align="center">

![logo](asset/UPPERIOC.png)

</div>

<h1 align="center">UPPERIOC</h1>

<p  align="center">

 
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


MyGet Pre-release feed: https://www.nuget.org/packages/UPPERIOC/

| Package | NuGet Stable | NuGet Pre-release | Downloads | MyGet |
| ------- | ------------ | ----------------- | --------- | ----- |
| [UPPERIOC](https://www.nuget.org/packages/UPPERIOC/) | [![CNative.Dapper.Utils](https://img.shields.io/nuget/v/UPPERIOC.svg)](https://www.nuget.org/packages/UPPERIOC/) | [![UPPERIOC](https://img.shields.io/nuget/vpre/UPPERIOC.svg)](https://www.nuget.org/packages/UPPERIOC/) | [![UPPERIOC](https://img.shields.io/nuget/dt/UPPERIOC.svg)](https://www.nuget.org/packages/UPPERIOC/) | [![UPPERIOC MyGet](https://img.shields.io/myget/UPPERIOC/vpre/UPPERIOC.svg)](http://8.138.99.154:5000/packages/upperioc/2.0.4.15) |

### 首先声明

本项目是一个IOC容器和插件集 ，提供给Winform开发者加速构建你的 **单体应用程序**  目前对windows支持良好 。如果有意和我共同开发跨平台版本，可以私信我，建议 **个人学习** 使用，没有针对性能做过特殊调优，大项目请选择性使用，如选择使用，代表您了解此项目可能存在漏洞，并且愿意承担可能的风险。如果此项目让你感觉还不错，可以留下一个 **star**  :star:

### 2025计划


1. 准备将模块化开发模式等复杂的配置，基于标签注册，全面小白化，小白也能轻松使用，开发一个类似SpringBoot的全注解启动的版本
2. 以及对部分风险功能：例如注册软件，配置文件实体映射，做更全面的加密优化。
3. 寻找一些适合上位机的orm框架，继承在容器中，最好是提供一些对版本迭代的优化，部分新手上位机玩家在数据库管理容易出现的问题提供解决方案。
4. 继续完善文档和架构，使软件更加优美整洁。


### **UPPERIOC**

目前包含了以下的功能，而且在应用中 **提供了一个插件集合** 希望您学习使用UPPERIOC的基本使用方法。
项目是个人开发并且 **完全开源** ，后期假如一直在这个行业就会一直维护。可以用来申请专利还有二次开发。无版权问题。

### 核心用法

```csharp
static void main() {
	var config = new UPPERIOC.UPPER.IOC.Center.Configuation.MoudleConfiguaion();
	config.AddMoudle<UPPERIOCMoudle>(); //新版中此模块是默认模块
	config.AddMoudle<UPPERLogFileMoudle>();
	config.AddMoudle<UPPERSendorMoudle>();
	config.AddMoudle<UPPERMLockMoudle>();
	config.AddMoudle<UPPERPremissionMoudle>();
	config.AddMoudle<UPPERFileModelMoudle>();
	config.AddMoudle<UPPERErrorMoudle>();
	config.AddMoudle<UPPERTranslateMoudle>();
	config.SetProvider<UPPERDefaultProvider>(); // 新版中可以省略
	UPPERIOCApplication.RunInstance(config);
	Application.Run(new Form1());
}
```

在应用启动时加载模块，意味着模块的生命周期将会伴随您的应用同生同灭。我们提供了许多模块方便您的开发。

#### Sendor

Sendor的用法很简单，提供一个消息类，便可以实现依赖反转式的通信，很好的解耦了软件中的层级关系。

```csharp
///注册一个消息Sendor
SendorCenter.Register<object>(x =>
{
	LogCenter.Log(x.ToString());
});

//触发消息Sendor
SendorCenter.Publish<object>("HelloWorld");
```
XXXXXXXX.XXX:
Debug - 14:06:26:1892:HelloWorld
#### Log

是我提供的一个统一的接口，任何实现了 ILog 的类都可以注册进来，并且提供了一个默认的实现（ FileLog ），使用 FileLog 需要你配置一个 IFileLogConfiguation 配置类，并且注入到容器中，可以使用你自己的 Provider 注入，也可以使用默认提供的 UPPerContainerProvider 的实现注入。你也可以使用我内置的IOC模块使用注解 [IOCObject] 注入

```csharp
//1.注册一个文件日志中心
 config.AddMoudle <UPPERLogFileMoudle>();
//2.实现IFileLogConfiguation接口
internal class FCTUFileConfiguation : IFileLogConfiguation
{
    public string DirectoryName { get => "FCTlog"; set => throw new NotImplementedException(); }
    public string DefaultExt { get => ".log"; set => throw new NotImplementedException(); }
    public List<LogType> WhichTypePrint { get => new List<LogType> { LogType.Debug, LogType.Warn, LogType.Info, LogType.Error, }; set => throw new NotImplementedException(); }
    public string FileNameTimeFormat { get => "日志yyyyMMdd"; set => throw new NotImplementedException(); }
    public int HowManyHourSave { get => 48; set => throw new NotImplementedException(); }
    public bool PrintMs { get => true; set => throw new NotImplementedException(); }
}
//3.在执行注入了一个Provider后，将实例注入容器中
config._containerProvider.Rigister<FCTUFileConfiguation>(new FCTUFileConfiguation());
//或者
U.C.Rigister<FCTUFileConfiguation>(new FCTUFileConfiguation());
//或者在类上写上特性[IOCObject]

//4.通过LogCenter.Log("Hello")使用日志功能
LogCenter.Log("Hello")
```

正常在应用程序根目录的子文件夹中就会有一个 日志20250501.log 中有一行日志 
Debug - 14:06:26:1892:Hello

#### Model

Model是一个将文件序列化和反序列化能力的模块，接下来将为您演示

```csharp
//1.注册一个文件日志中心
 config.AddMoudle <UPPERFileModelMoudle>();

//2.实现IUFileModelConfiguation接口
internal class UFileModelConfigration : IUFileModelConfiguation
{
    public string SaveModelPath 
    {
        get => "conf"; 
        set => throw new NotImplementedException();
    }
}

//3.将实例注入容器中
config._containerProvider.Rigister<UFileModelConfigration >(new UFileModelConfigration ());

//4.通过F.I使用实例化功能 where T:IModel
F.I.SaveModel(new T());
var t = F.I.GetModel(new T());

//你可以使用[XmlIgnore]忽略项目使其不存储。
```

#### IOC

UPPERIOC集成了注解注入式容器，主要是项目中整合其他模块的时候可以使用,有时候使用 [IOCObject] 便可以直接使用，而无需在 UPPERApplication.RunInstance(conf) 之前使用 Provider 一个个注册，这样代码会显得很冗余。
用法：

```csharp
config.AddMoudle<UPPERIOCMoudle>();//引入模块
//注册一个实例
[IOCObject]
public class VerContent
{
    public string Up;
    public string Ver;
    public string Content;
}

//使用注册的实例
U.C.GetInstance<VerContent>();

```

#### Util

小工具集合，文档加速整理中...

#### MLock

一个可以让你的应用必须注册才可以使用的工具
```csharp
//1.实现MLockConfiguation类
public class MLockConfiguation
{
    /// <summary>
    /// 注册机使用的盐值
    /// </summary>
    public virtual string Solt { get; set; }
    /// <summary>
    /// 在注册表或者在文件中的目录名称
    /// </summary>
    public virtual string Listenaddr { get; set; }
    /// <summary>
    /// 文件或者在注册表的项目名称
    /// </summary>
    public virtual string LockName { get; set; }
    /// <summary>
    /// 如果没有注册的逻辑实现，是提示或者让他注册
    /// </summary>
    public virtual void Noregister() {
        Console.Write("没有注册");
        Environment.Exit(0);
    }
}

 //2.应用模块并注册您的实现类
config.AddMoudle<UPPERMLockMoudle>();

//先设置默认的提供类实例
config.SetProvider<UPPERDefaultProvider>();
config._containerProvider.Rigister<ILockConfiguation>();

```

####  SimplePremission

小权限系统，文档加速整理中...

####  Translate

一个翻译模块。可以实现按需翻译你的应用，傻瓜式操作，有手就行。

```csharp
//1.注册一个ITranslateConfig的实例，实际参数需要填写有道词典你的信息
public  interface ITranslateConfig
{
    string APPKey { get; }
    string APPSeret { get; }
    string FromLanguage { get;  }
    string ToLanguage { get;  }
}

//2.使用Translate翻译模块需要在启用容器的时候调用
config.AddMoudle<UPPERTranslateMoudle>();

//3.然后在需要翻译的窗体加载完成后调用函数
TranslateCenter.Instance.SetRootWindows(this);

//3. OR 也可以显式的使用
Control.Property = TranslateCenter.Instance.SetText(Control.Property);

//模块会在路径Model/translate生成一个文件，你可以用文本打开，然后依次翻译词条。但是我们推荐使用接口翻译。需要你实现一个ITranslateConfig接口，并注入到容器中。容器会在SetText没有翻译的情况下使用有道词典进行翻译。

```

### 软件架构

UPPERIOC.UPPERApplication -核心启动类

UPPERIOC.\*.Moudle -需要加载的模块

UPPERIOC.\*.Center -用户直接交互的类

UPPERIOC.\*.IConfigration -模块中用户需要自己实现的配置类（注册）

UPPERIOC.\*.IModel -模块中用户需要自己实现的模型类（注册）

### 问题

1. IOCObject属性失效
  
```
  生成的时候检查是否有提示“CSC : warning CS9057: 分析器程序集“C:\Users\1\.nuget\packages\upperioc\2.0.4.20\analyzers\dotnet\roslyn3.8\cs\IOCCodeGenerator.dll”引用了编译器的版本“4.12.0.0”，该版本高于当前正在运行的版本“4.10.0.0”。”
  这表示你需要在nuget中引用microsoft.codeanalysis.csharp 4.10.0以上的版本（以实际为准）
```

2. XXXConfiguation对象没有找到

```
    可能是1的bug，或者使用U.C注册
```

3. 文件中的类都不能进行设计，因此未能为该文件显示设计器，设计器检查出文件中有以下类:FrmDialog请确保已引用该程序集并已生成所有项目

```
    生成包即可
```

