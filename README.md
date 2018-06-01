# Newtonsoft Json.NET Aot for .NET Standard 2.0

This implementation is actually a fork of the excellent work of SaladLab, Json.Net.Unity3D, and of course, the excellent work of the initial author, Newtonsoft !

# Why this fork ?

With the arrival of Blazor, a C#/Mono Framework for web browser, it was necessary for my projects to be able to use the same kind of reference library and behavior among projects.

The initial project is not specially AOT friendly, and as JIT is forbidden on some AOT plateforms like iOS / Blazor (as the Mono stack does not ship System.Reflection.Emit), it was difficult to share some JSON structures on all the plateforms i want to support at the same time (Android, iOS, UWP, Blazor).

The goal of SaladLab was to make Json.NET compatible with Unity3D (and so Aot friendly), and was compiled on the .NET 3.5 framework.
The goal of this fork was to upgrade the whole project on .NET Standard 2.0 format, with Unity3D DEFINE CONSTANT preferences.

I had to drop to be able the test project, as there is many differences between API i don't want to take time to resolve, mainly related to some SQL stuff.

## Where can I get it?

Visit [Release](https://github.com/SaladLab/Json.Net.Unity3D/releases)
page to get latest Json.NET unity-package.

To use this library in IL2CPP build settings, you need to add
[link.xml](https://github.com/SaladLab/Json.Net.Unity3D/blob/master/src/UnityPackage/Assets/link.xml) to your project's asset folder.
For detailed information about link.xml, read unity [manual](http://docs.unity3d.com/Manual/iphone-playerSizeOptimization.html) about this.

## What's the deal?

Unity3D has old-fashioned and bizarre .NET Framework like these :)
 - Basically based on .NET Framework 3.5 ([forked Mono 2.6](https://github.com/Unity-Technologies/mono/commits/unity-staging))
 - Runtime lacks some types in .NET Framework 3.5 (like System.ComponentModel.AddingNewEventHandler)
 - For iOS, dynamic code emission is forbidden by Apple AppStore.

Because Newtonsoft Json.NET doesn't handle these limitations, errors will welcome you
when you use official Json.NET dll targetting .NET 3.5 Framework.

## What's done?

Following works are done to make Json.NET support Unity3D.

 - Based on Newtonsoft Json.NET 9.
 - Disable IL generation to work well under AOT environment like iOS.
 - Remove code related with System.ComponentModel.
 - Remove System.Data and EntityKey support.
 - Remove XML support.
 - Remove DiagnosticsTraceWriter support.
 - Workaround for differences between Microsoft.NET & Unity3D-Mono.NET

For Unity.Lite version, additional works are done to make more lite.

 - Remove JsonLinq, JPath (JToken, ...)
 - Remove Bson
