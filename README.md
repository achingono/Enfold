# Enfold

This project is a demonstration of how to generate Javascript bundles dynamically.

## Installation

```
PM> Install-Package Enfold.Javascript
```

## Usage

**Global.asax**

```c#
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            BundleTable.Bundles.RegisterScriptBundles();
        }
    }

```

**Layout.cshtml**

```
<body>
    ...
  @Scripts.Render(this.Request.Bundle())
</body>
```

## Organizing your files

Assuming you have the following views in the web project:
> ~/Views/Home/About.cshtml  
> ~/Views/Home/Contact.cshtml  
> ~/Views/Home/Index.cshtml

You can organize your Javascript files this way:
> ~/Scripts/Views/default.js  
> ~/Scripts/Views/Home/default.js  
> ~/Scripts/Views/Home/about.js  
> ~/Scripts/Views/Home/contact.js  
> ~/Scripts/Views/Home/index.js  

With such a setup, the following bundles will be created:
> **~/bundles/home/about**  
> >~/scripts/views/default.js  
> >~/scripts/views/home/default.js  
> >~/scripts/views/home/about.js  
> 
> **~/bundles/home/contact**  
> >~/scripts/views/default.js  
> >~/scripts/views/home/default.js  
> >~/scripts/views/home/contact.js  
> 
> **~/bundles/home/index**  
> >~/scripts/views/default.js  
> >~/scripts/views/home/default.js  
> >~/scripts/views/home/index.js  
