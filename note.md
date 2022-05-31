



<font color="red">运行解释器指令</font>

```
# 编译解释器 interpc.exe 命令行程序 
dotnet restore  interpc.fsproj   # 可选
dotnet clean  interpc.fsproj     # 可选
dotnet build -v n interpc.fsproj # 构建./bin/Debug/net6.0/interpc.exe ，-v n查看详细生成过程

./bin/Debug/net6.0/interpc.exe example/ex1.c 8

```



<font color="red">运行编译器指令</font>

```
# 构建 microc.exe 编译器程序 
dotnet restore  microc.fsproj # 可选
dotnet clean  microc.fsproj   # 可选
dotnet build  microc.fsproj   # 构建 ./bin/Debug/net6.0/microc.exe

# 编译 c 虚拟机
gcc -o machine.exe machine.c

# 虚拟机执行指令
.\machine.exe ./example/ex9.out 3
```



## 实现内容

