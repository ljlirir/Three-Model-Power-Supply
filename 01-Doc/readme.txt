



//////////////////////////////////////////////////////////////////////////////////////////////////////////////
程序执行简明流程：

【1】在Program.cs文件中启动运行Form1.cs
     应用程序的主入口点为Main()：
         Application.Run(new Form1());

【2】在Form1.cs中运行构造函数，进行窗体初始化
         InitializeComponent();
     Load为用户加载窗体时发生的事件，在窗体属性窗口的事件设置栏目设置Load事件
     的“事件处理函数”的名字为：_Load
         因此，在 InitializeComponent()函数中有下列语句;
         this.Load += new System.EventHandler(this.Form1_Load);
         表示发生Load事件时，将执行Form1_Load函数

【3】开始运行窗体的Load事件处理函数Form_Load
【4】PublicVar.cs中定义了全局变量，供其他类使用