# Sitecore.Lighthouse

[![Build status](https://ci.appveyor.com/api/projects/status/jsjfx04v9u929os2?svg=true)](https://ci.appveyor.com/project/Antonytm/sitecore-Lighthouse)
![GitHub top language](https://img.shields.io/github/languages/top/antonytm/sitecore.lighthouse)

## IMPORTANT

It was tested only with Sitecore hosted on-premise. It is not recommended to install and run it on Sitecore XM Cloud.

## Abstract:

Integration of Google Lighthouse with Sitecore.



## Requirements:
Sitecore 8+

The project is built following Helix principles, but you can use it in any Sitecore project.

## How to install

1. Download the Sitecore update package: a) from [Github releases](https://github.com/Antonytm/Sitecore.Lighthouse/releases) if you want a stable version; b) from [AppVeyor](https://ci.appveyor.com/project/Antonytm/sitecore-Lighthouse) if you want the latest version
2. Install it using update installation wizard /sitecore/admin/UpdateInstallationWizard.aspx
3. You must inherit page templates from "/sitecore/templates/Foundation/Lighthouse/Partial/_Lighthouse". It is required to provide the tool ability to save service information to page items.
![Inheritance](/docs/images/inheritance.png)

## How to use 

After installation of Sitecore update package, you will get the new ribbon in Content Editor:
![Sitecore Ribbon](/docs/images/ribbon.png)
Buttons on Ribbon allow you run, and run for all pages and sites, view chart statistics, and view the latest report.

### Run Google Lighthouse report for the page(item)
![Run](/docs/images/run.png)

It will execute Google Lighthouse for the current page and save results to the Lighthouse section of the item. 
![Service data](/docs/images/serviceData.png)

After running it, you will be able to see the latest report or chart for this page.

### Run Google Lighthouse report for all pages(items)
![Run all](/docs/images/runAll.png)

It will start the background process to run Google Lighthouse for all websites and pages that are inherited from "_Lighthouse" template.
Be patient, it takes some time to finish it for all pages on your websites.

### View chart that provides statistics of previous runs
![Chart](/docs/images/chart.png)

You are able to see the history of main parameters changes after running report preparation for selected item.
![Chart example](/docs/images/chartExample.png)

### View the latest report for the page
![Latest report](/docs/images/latest.png)

You are able to see the latest report by clicking the Latest button. 
![Latest report example](/docs/images/latestExample.png)

If you want to find some previous reports, you can find them on the disk, where your Sitecore is installed in folder App_Data\Lighthouse\Reports. 

### View summarized website statistics
Your website summary of the Google Lighthouse report is saved under /sitecore/system/Modules/Lighthouse in the master database. You are able to navigate to the website you are interested in and see chart statistics for it, items with worst performance, items with best performance and logs. If for some page tool was not able to gather data then the path for these items and the reason will be present in logs.
![Site summary](/docs/images/siteSummary.png)
