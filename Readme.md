# 此项目为前端学习项目 后面会调用WebAPI进行数据交互
# 此项目技术栈为 Blazor Server + bootstrap +	html混合

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

1.正确引入MudBlazor包(不支持net10)
```
登陆Mudblazor官网，查看说明文档 https://mudblazor.com/getting-started/installation
1：nuget下载MudBlazor
2：_Imports.razor 引入MudBlazor命名空间
3：Program.cs  引入MudBlazor服务
4：根据说明文档 重写 MainLayout.razor 引入MudBlazor样式

5：根据说明文档 重写 NavMenu.razor 使用MudBlazor组件

6：App.razor  使用MudBlazor组件
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

8.空合并赋值运算符
```
当左侧为 null 时，将右侧的值赋给左侧；否则保持左侧原值不变。
server ??= ServerRepository.GetById(id);  
```

9.数据注解和表单验证(MudBlazor有现成的)

10.导航管理器 NavigationManager 依赖注入 inject 注册和webapi一样

11.流式渲染 @attribute [StreamRendering]

12.交互性和非交互性 应用程序
```
•交互性应用（interactive）：页面在浏览器端有活跃的运行时，能响应用户事件（@onclick、表单交互）、
局部重渲染并保持组件状态。Blazor 的交互性由 Blazor 运行时提供（Blazor.web.js文件）。
非blazor应用的交互性通常由 JavaScript 提供。
•非交互性应用（non‑interactive）：服务器返回的是静态或服务器端完全渲染的 HTML，客户端没有或没有激活运行时，
用户交互只能通过整页刷新提交到服务器（传统静态站点、纯 SSR 页面、或只做预渲染但不激活的组件）。
```
13.增强导航

```
切换界面时，更新部分界面而不刷新整个页面，是实现交互性应用程序的关键。Blazor 提供了增强导航功能(Blazor.web.js文件)。
```
14.增强表单   
```
Enhance= "true"
```

15.blazor的交互式服务端渲染/静态服务端渲染
```
交互式服务端渲染：
SignalR 通道:小数据的更新，框架自带。 
需要开启交互性配置:
在program.cs中配置 + 渲染方式(@rendermode="InteractiveServer",推荐在使用处，指定组件渲染方式，可在全局位置(App.razor中的<Routes />)设置)
1.创建交互性应用程序，交互模式 选择Server
2.可以选择 单页渲染 或者 全局渲染(@rendermode="InteractiveServer" 位置不同)

静态服务端渲染：
http请求:大数据的更新，需要手动调用 HttpClient。
有些指定cookies/session的请求，SignalR通道无法处理，需要使用HttpClient。
如果想指定组件为静态渲染，可以使用 @attribute [ExcludeFromInteractiveRouting] 特性排除交互式,此组件必须是可路由组件(@page 指令)。

```

16.视图-状态双向数据绑定
```
// 双向绑定语法糖
<input type="text" class="form-control" placeholder="搜索服务器" @bind-value="serverFilter" @bind-value:event="oninput" />


</details>



