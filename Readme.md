# 此项目为前端学习项目 后面会调用WebAPI进行数据交互

## 项目结构
```
Step1  app.MapRazorComponents<App>(); 中间件
Step2  App.razor 根组件
Step3  Routes.razor 路由组件
Step4  MainLayout.razor 布局组件
Step5  Pages 组件页面/自定义组件
```

## 知识
```
可路由组件(必须加 @page 指令)

@page "/servers"
<h3>Servers</h3>
@code {
....
}

不可路由组件(没有 @page 指令，其他组件可以使用)


全局命名空间 _imports

隐式razor表达式
显式razor表达式