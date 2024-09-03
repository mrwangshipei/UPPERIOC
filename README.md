# UpperComAutoTest

#### 首先声明
 本项目处于 **初版出来的阶段** ，提供给开发者加速构建你的 **单体应用程序** ，功能基本正常，但是 **难免会有一些坑要踩** ，建议 **个人学习** 使用
 

### **UPPERIOC**
目前包含了 以下的功能，而且在应用中 **提供了一个类似串口助手的东西** ：：不是很正式，用于学习使用UPPERIOC的基本使用方法。
 项目是个人开发 **完全开源免费** ，后期假如一直在这个行业就会一直维护。可以用来申请专利还有二次开发。无版权问题，只要
![输入图片说明](src=http___image109.360doc.com_DownloadImg_2018_09_1103_143832249_2_20180911034746566&refer=http___image109.360doc.webp)
```
> Sendor
的用法很简单，提供一个消息类，便可以实现依赖反转式的通信，很好的解耦了软件中的层级关系。
> Log
是我提供的一个统一的接口，任何实现了 ILog 的类都可以注册进来，并且提供了一个默认的实现（ FileLog ），使用 FileLog 需要你配置一个 IFileLogConfiguation 配置类，并且注入到容器中，可以使用你自己的 Provider 注入，也可以使用默认提供的 UPPerContainerProvider 的实现注入。你也可以使用我内置的IOC模块使用注解 [IOCObject] 注入
> Model
Model我用的也不是很多，这意味着可能会有潜在的错误未被发现，但是我是有一个项目正在使用 Model 的。建议不用。
> IOC
IOC就是集成了一些注解注入式容器，目前是可用的，但是相对成熟的IOC容器是有很大的差距的，主要是项目中整合其他模块的时候有时候使用 [IOCObject] 便可以直接使用，而无需在 UPPERApplication.RunInstance(conf) 之前使用 Provider 一个个注册，这样代码会显得很冗余
> Util
目前这里面有两个模块，一个 MustRunAsAdminMoudle 如果你在 RunInstance 之前是用了这个模块，那么他会提醒并让你的应用必须以管理员模式打开，
第二个模块 SimpleOnlyRunProcessMoudle 能保证你的应用只会打开一个，当你打开第二个的时候会唤醒第一个打开的应用，并关闭第二个打开的应用。需要注意的是，应用是使用默认的ProcessName识别的，所以请保证你的ProcessName不会与其他应用冲突
> SimplePremission
一个简单的单体应用权限系统解决方案，通过配置 IPremissionConfiguation 配置权限系统的初始化，窗体，还有一些基本信息。需要注意的是，使用简单的权限系统需要实现RigisterObjLoad 来初始化权限的保存方式，无论如何，你必须持有一个 RigisterObjLoad 的对象在容器中，这个对象会管理权限系统的保存在系统中的方式，默认是以注册表的形式保存的。
还有一件你要关心的，就是权限系统的用法，我提供了两种用法，一种是直接通过权限标识在需要权限的时候访问，当前用户无权限就会抛出异常。一种是使用Mvvm在vm层将需要权限的类授予 ProxyClass 标签 而方法标记上 PremissionRequired 标签，这样vm的生命周期都将交给IOC管理，在需要vm的时候使用我的IOC容器，会提供一个经过AOP的子类。

```

#### 软件架构

 **UpperComAutoTest** 

软件架构说明
View -视图层
ModelView -逻辑层
Model -对象层
Dao -串口通信层


 **UPPERIOC**

UPPERIOC.UPPERIOCCenter -核心启动类

UPPERIOC.*.Moudle -需要加载的模块

UPPERIOC.*.Center -用户直接交互的类

UPPERIOC.*.IConfigration -模块中用户需要自己实现的配置类（注册）

UPPERIOC.*.IModel -模块中用户需要自己实现的模型类（注册）

#### 安装教程

pull之后可以直接用vs2022打开


