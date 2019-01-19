# NanoLeaf C# API

[![Build status](https://ci.appveyor.com/api/projects/status/uk4se82ak2bov8re?svg=true)](https://ci.appveyor.com/project/Silverdark/nanoleaf-api) 
[![Current Version](https://img.shields.io/nuget/v/nanoleaf.api.svg)](https://www.nuget.org/packages/nanoleaf.api/)

## Description

The NanoLeaf C# API is a library which abstracts the "low-level" API calls of the [Nanoleaf Light Panels OpenAPI](http://forum.nanoleaf.me/docs/openapi).

## Example project

There's an example project under `src/NanoLeaf.API.BasicExample` which prints some basic information about a NanoLeaf controller. With the usage of the [Public Postman API](https://documenter.getpostman.com/view/1559645/RW1gEcCH) I have mocked the requests with following result:

![image](https://user-images.githubusercontent.com/3630571/51432907-0cd0b580-1c40-11e9-8cf4-f3a98ff18b4a.png)

## Disclaimer

I don't own a NanoLeaf panel / controller myself, so I couldn't test this library myself. Thanks to the [Nanoleaf Light Panels OpenAPI](http://forum.nanoleaf.me/docs/openapi) (you have to register first) and especially this fantastic [Public Postman API](https://documenter.getpostman.com/view/1559645/RW1gEcCH) I tested the library as good as I could.

If there are any problems, I'd be happy if you opened up an [Issue](https://github.com/Silverdark/NanoLeaf.API/issues).

This library was developed in my spare time, so please don't ask when something is done. If it is urgent, don't hesitate to create a [Pull request](https://github.com/Silverdark/NanoLeaf.API/pulls).