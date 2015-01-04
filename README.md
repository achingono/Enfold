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

## Settings

Settings can be adjusted in the `web.config` file:

```xml
<enfold scriptPath="~/Scripts/Views" scriptExtension=".js" defaultScriptFileName="default" bundlePrefix="~/bundles" />
```

### ScriptPath
This is the path where script files are located. The code will scan this folder and generate bundles based on contents of this folder. The default value is `~/Scripts/Views`.

### ScriptExtension
This is the extension of script files to search for in the `scriptPath`.

### DefaultScriptFileName
This is the name of the file treated as a common file for all scripts in a particular hierarchy. The default value for this setting is `default`.

### BundlePrefix
This is the prefix added to all generated bundles. The default value for this setting is `~/bundles`.
