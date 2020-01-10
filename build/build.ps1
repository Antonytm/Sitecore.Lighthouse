$version = $env:APPVEYOR_BUILD_VERSION
if ($version -eq $null) {
    $version = "1.0.0"
}
"Package version: " + $version

Remove-Item build\package -Recurse -ErrorAction Ignore
Remove-Item build\artifacts -Recurse -ErrorAction Ignore
New-Item -Name build\package -ItemType directory
New-Item -Name build\artifacts -ItemType directory
New-Item -Name build\package\Data -ItemType directory
New-Item -Name build\package\bin -ItemType directory
New-Item -Name build\package\App_Config\Include\Foundation -ItemType directory
New-Item -Name build\package\App_Data\Lighthouse\Tools -ItemType directory
New-Item -Name build\package\App_Data\Lighthouse\Reports -ItemType directory


Copy-Item .\src\Foundation\Lighthouse\code\bin\Foundation.Lighthouse* .\build\package\bin
Copy-Item .\src\Foundation\Lighthouse\code\App_Config\Include\Foundation\Foundation.Lighthouse.config .\build\package\App_Config\Include\Foundation
Copy-Item ".\lighthouse tools\*" .\build\package\App_Data\Lighthouse
Copy-Item .\src\Foundation\Lighthouse\serialization\* .\build\package\Data -recurse

$packageCmd = "Sitecore.Courier.Runner.exe -t build\package -o build\artifacts\sitecore.lighthouse." + $version + ".update -r"
iex $packageCmd