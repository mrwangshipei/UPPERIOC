# UpperComAutoTest

#### 介绍
 **UpperComAutoTest** 是一个基于.net framework开源的串口助手,采用了Mvvm的设计模式，遵守了开发的三大范式。供学习使用。

 **UPPERIOC**是一个学习中自己扩展的一个mvvm支持包，目前包含了 **Sendor** ，   **Log<FileLog>** , **Model<FileXmlModel>**, **IOC **,  **VersionControl**的功能，随着学习会加入更多的功能。 
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


