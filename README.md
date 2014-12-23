Enfold
======

This project is a demonstration of how to generate Javascript bundles dynamicamically.

Usage
=====

> **Global.asax**

```c#
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.RegisterScriptBundles();
        }
    }

```

> **Layout.cshtml**

```
<body>
    ...
  @Scripts.Render(this.Request.Bundle())
</body>
```