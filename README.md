# Dimension
# 基于 .NET 6 搭建的WPF程序和ASP.NET API服务。  
**后台部署说明**  
1. 修改DimensionService.Common命名空间下 ClassHelper类  
![image](https://user-images.githubusercontent.com/84434846/159858628-cfcd7669-fae3-41b6-bd74-700e117c8870.png)  
请填写红框内付费服务内容，本程序使用阿里的短信服务和腾讯的TRTC服务，填写内容请见官方说明。  
2. 数据库  
该服务采用sqlserver2019数据库，并使用EF CORE作为主要的ORM框架，首次使用需要迁移数据库。  
打开程序包管理控制台，输入Update-Database InitialCreate  
![image](https://user-images.githubusercontent.com/84434846/159859559-e69a1d8e-fe6a-42f6-841e-980b20533ad4.png)  
该项目提供线上测试服务地址，http://47.96.133.119:5000  
# WPF端  
![image](https://user-images.githubusercontent.com/84434846/159860811-31419d6d-97a0-4f40-9536-c555d6140fd4.png)  
红框内容需与服务端保持一致  
已实现的功能  
1.登录|注册  
2.添加好友  
3.音视频在线通话  
4.聊天（图片、文字、富文本）  
5.截屏（多显示器不同dpi支持）  
# 功能演示
作者太懒，以后再写！  
我还是提供的测试账号和程序地址吧。  
不过需要安装NET6桌面运行时，这是下载地址：https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-6.0.3-windows-x64-installer  
# 测试用户  
1571221{1～9}177，
密码统一为12345678。  
所有用户登录信息我都放在程序包里啦，并且都添加了我做为好友。😄  
![image](https://user-images.githubusercontent.com/84434846/159868799-ed024f69-d91f-48d7-a52f-961502a89445.png)  
# 程序包
链接：https://pan.baidu.com/s/1Ux4R7NreZ3Lk6NBgnqn9IQ?pwd=qz57 
提取码：qz57 
--来自百度网盘超级会员V4的分享
# 演示视频
链接：https://pan.baidu.com/s/1n-sQZFgO9GEhS80jHLVouA?pwd=85x3 
提取码：85x3 
--来自百度网盘超级会员V4的分享
