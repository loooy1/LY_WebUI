# 此项目为前端学习项目 后面会调用WebAPI进行数据交互

<details>
<summary>## 项目结构</summary>

1.项目结构说明
```
Step1  app.MapRazorComponents<App>(); 中间件
Step2  App.razor 根组件
Step3  Routes.razor 路由组件
Step4  MainLayout.razor 布局组件
Step5  Pages 组件页面/自定义组件
step6  wwwroot 静态资源
```
</details>


<details>
<summary>## 包</summary>

1.正确引入MudBlazor包
```
1：nuget下载MudBlazor
2：_Imports.razor 引入MudBlazor命名空间
3：Program.cs  引入MudBlazor服务
4：MainLayout.razor 引入MudBlazor样式
@* 引入MudBlazor样式 *@
{
@* Required *@
<MudThemeProvider />
<MudPopoverProvider />

@* Needed for dialogs *@
<MudDialogProvider />

@* Needed for snackbars *@
<MudSnackbarProvider />
}

5：App.razor  使用MudBlazor组件
@* 使用MudBlazor组件 *@
<link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" rel="stylesheet" />
<link href="@Assets["_content/MudBlazor/MudBlazor.min.css"]" rel="stylesheet" />

```
</details>



<details>
<summary>## 知识</summary>

1.可路由组件(必须加 @page 指令)
 ```
@page "/servers"
<h3>Servers</h3>
@code {
....
}
```
2.不可路由组件(没有 @page 指令，其他组件可以使用)

3.全局命名空间 _imports

4.隐式razor表达式
```
 <h3>@Title</h3>
 @code {
	 string Title = "Hello, World!";
 }
```
5.显式razor表达式
```
 <h3>@(Title)</h3>

```
6.路由参数及约束

7.EditForm 表单组件 model绑定

</details>



