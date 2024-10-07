# Sitecore.Lighthouse

[![Build status](https://ci.appveyor.com/api/projects/status/jsjfx04v9u929os2?svg=true)](https://ci.appveyor.com/project/Antonytm/sitecore-Lighthouse)
![GitHub top language](https://img.shields.io/github/languages/top/antonytm/sitecore.lighthouse)

## Abstract:

Integration of Google Lighthouse with Sitecore

## Requirements:
Sitecore 8+

Project is build following Helix principles, but you can use it in any Sitecore project.

## How to install

1. Download Sitecore update package: a) from [Github releases](https://github.com/Antonytm/Sitecore.Lighthouse/releases) if you want stable version; b) from [AppVeyor](https://ci.appveyor.com/project/Antonytm/sitecore-Lighthouse) if you want latest version
2. Install it using update installation wizard /sitecore/admin/UpdateInstallationWizard.aspx
3. You need to inherit your pages templates from "/sitecore/templates/Foundation/Lighthouse/Partial/_Lighthouse". It is required to provide ability for tool to save service information to page item.
![Inheritance](/docs/images/inheritance.png)

## How to use 

After installation of Sitecore update package, you will get new ribbon in Content Editor:
![Sitecore Ribbon](/docs/images/ribbon.png)
Buttons on Ribbon allows you run, run for all pages and sites, view chart statistics, view latest report.

### Run Google Lighthouse report for page(item)
![Run](/docs/images/run.png)

It will execute Google Lighthouse for current page and save results to Lighthouse section of item. 
![Service data](/docs/images/serviceData.png)

After running it, you will be able to see latest report or chart for this page.

### Run Google Lighthouse report for all pages(items)
![Run all](/docs/images/runAll.png)

It will start background process to run Google Lighthouse for all websites and pages that are inherited from "_Lighthouse" template.
Be patient, it takes some time to finish it for all pages on your websites.

### View chart that provides statistics of previous runs
![Chart](/docs/images/chart.png)

You are able to see history of main parameters changes after running report preparation for selected item.
![Chart example](/docs/images/chartExample.png)

### View latest report for page
![Latest report](/docs/images/latest.png)

You are able to see latest report by clicking Latest button. 
![Latest report example](/docs/images/latestExample.png)

If you want to find some previous report, you can find it on disc, where your Sitecore is installed in folder App_Data\Lighthouse\Reports. 

### View summarized website statistics
Your website summary of Google Lighthouse report is saved under /sitecore/system/Modules/Lighthouse in master database. You are able to navigate to website you are interested in and see chart statistics for it, items with worst performace, items with best performance and logs. If for some page tool was not able to gather data then path for these items and reason will be present in logs.
![Site summary](/docs/images/siteSummary.png)
