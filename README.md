Enfold
======

This project is a demonstration of how to generate Javascript bundles dynamically.

Installation
============

```
PM> Install-Package Enfold.Javascript
```

Usage
=====

> **Global.asax**

```c#
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            BundleTable.Bundles.RegisterScriptBundles();
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
