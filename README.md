# Grasshopper-virus

寄生于Grasshopper上的勒索病毒。提供了对称加密和非对称加密


Rhino版本为6.26.
.net版本为4.5


仅供学习使用，由此造成的一切后果，本人概不负责。强烈建议在虚拟机上实验。视频演示：

请想办法把gha文件拷贝到AppData\Roaming\Grasshopper\Libraries目录下，或者参考蠕虫gh脚本
https://github.com/architect-ghpython/Grasshopper-virus/tree/master/%E8%A0%95%E8%99%AB%E8%84%9A%E6%9C%AC%E5%AE%9E%E7%8E%B0 让gh文件都感染这个gha文件和c#脚本。在c#脚本中把gha写入AppData\Roaming\Grasshopper\Libraries目录下

   ![image](https://github.com/architect-ghpython/Grasshopper-virus/blob/master/4efbfdbc81f3135d12f0370f2ba3edf.png)
gha插件运行后，在C:\Users\AppData\Local\McNeel文件夹下创建5个文件。4.cmd和BypassUAC_Dll_csharp.dll利用dll注入的方法获得管理员权限.6.txt用于计算启动次数。 PublicKey.xml和PrivateKey.xml是非对称加密的公钥和私钥。
![image](https://github.com/architect-ghpython/Grasshopper-virus/blob/master/ae321788632de871a22d5944e5b83e5.png)

上图加密桌面不大于20M的文件
![image](https://github.com/architect-ghpython/Grasshopper-virus/blob/master/246f5320ee3091dd66cb4e25c661484.png)

上图，文件被非对称加密

![image](https://github.com/architect-ghpython/Grasshopper-virus/blob/master/62f29316cf74e9dc5d7803c9d4dc61f.png)

勒索信息，需要用比特币支付
![image](https://github.com/architect-ghpython/Grasshopper-virus/blob/master/9ae6f4a2aa9d08d3be6d5ca23228d14.png)
解密成功

参考
利用COM接口的ShellExec执行命令提权

https://github.com/cnsimo/BypassUAC
