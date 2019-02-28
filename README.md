# ChromeDevTools

[![Build status](https://ci.appveyor.com/api/projects/status/yvk96lqo7xgj5ib7/branch/master?svg=true)](https://ci.appveyor.com/project/diryboy/chromedevtools/branch/master)
[![Nuget](https://img.shields.io/nuget/v/DumbPrograms.ChromeDevTools.svg?logo=nuget)](https://www.nuget.org/packages/DumbPrograms.ChromeDevTools)

.Net library to interact with Chrome using the Chrome DevTools Protocol

When Chrome is started with `--remote-debugging-port=9222`, it can be controlled programatically via REST API and WebSocket using [Chrome DevTools Protocol](https://chromedevtools.github.io/devtools-protocol/).
This library provides .Net friendly API to work with the protocol.

## Getting Started

```
PM> Install-Package DumbPrograms.ChromeDevTools
```

If you already have Chrome running with `--remote-debugging-port=9222`, you can simply start with

```C#
var devTools = new DevToolsClient(9222);
```

This library includes `ChromeProcessHelper` to help you start Chrome with relavent commandline args

```C#
using (var chrome = ChromeProcessHelper.StartNew())
{
    var devTools = chrome.GetDevTools();
}
```

Once you have `DevToolsClient`, you can explore inspectable targets

```C#
var targets = from t in await devTools.GetInspectableTargets()
              where t.Type == "page"
              select t;
```

Then you can pick up a target and inspect

```C#
var t0 = targets.First();

using (var inspector = await devTools.Inspect(t0))
{
    await inspector.Page.Enable();

    await inspector.Page.Navigate("https://github.com");

    var e = await inspector.Page.LoadEventFiredEvent();

    Console.WriteLine($"Page loaded at {e.Timestamp.Value}");
}
```

Please keep in mind that these APIs are almost always async, putting `Async` suffices to the methond names are unnecessary.
Just remember to `await` the API calls unless you don't want.

## Building

Either use Visual Studio 2017 to open the solution and click the "Build Solution" button. Or

```
nuget restore
msbuild
```

## Refreshing

1. Make sure the Generator project is built.
1. Build the DevTools project with either `-property:RefreshProtocolJsonFiles=true` or your json files placed in the `Generated` folder.
