# Project 3: Barrel Bouncer AR Edition

## Part 1: Setting Up Your Project for AR

In this section, you'll be configuring your Unity project for mobile AR development. This will involve modifying project settings as well as installing the XR development tools that you will use to build your app. Note that we will be testing your submission on Android phones, so you are only required to configure the project for ARCore development. However, if you plan on testing the app on your own iOS device, you should set the appropriate iOS and ARKit settings as well. Instructions for both have been included below.

_NOTE: For this project, you will be building on top of a copy of your completed project 1c,_ **NOT** _your project 2. If you do not have a copy of this, you may download your submission on ELMS and then open it up in Unity. If you do it this way, it you should select the correct_ **Target Platform** _within the Unity Hub before opening it in order to save you time._

### General Project Settings

#### Build Settings

Open up your _**Build Settings**_, and make sure to switch the target platform to either iOS or Android, depending on what platform you will be testing on. Additionally, you can uncheck all of the scenes in the build for the time being.

#### Player Settings

Open up your _**Player Settings**_ and set them to the values listed below.

##### Common

While most Player Settings in Unity are platform-specific, there are a few settings that are shared between multiple platforms. Changing one of these settings when you're on one platform's tab will automatically set the same setting for the other platform's as well.

- **General**
  - **Product Name:** LastName_FirstName_BarrelBouncer_AR
    - _This is the name of the app that you will see when it is installed to your phone._
- **Resolution and Presentation**
  - **Orientation**
    - **Default Orientation:** Portrait
- **Other Settings**
  - **Rendering**
    - **Multithreaded Rendering:** ✓

##### Android-Specific

Since you are required to submit an `.apk` file to us, you should make sure to adjust the following settings while the Android tab is selected in your Player Settings.

- **Other Settings**
  - **Rendering**
    - **Auto Graphics API:** (unselected)
    - **Graphics APIs:** (Vulkan removed)
      - _Vulkan is a relatively new cross-platform 3D graphics API with low-overhead and high-performance, and was previously referred to as a "next generation OpenGL initiative". It is included as the default graphics option for the Android platform in Unity but is not currently supported by Google for ARCore applications._
  - **Identification**
    - **Package Name:** com.LastName.FirstName.BarrelBouncer.AR
      - _This is your app’s unique identifier on the phone (and the Google Play Store, if you submit it there)._
    - **Minimum API Level:** Android 7.0 'Nougat' (API level 24)
      - _This is the earliest version of Android that supports ARCore._
  - **Configuration**
    - **Scripting Backend:** IL2CPP
      - _The IL2CPP scripting backend has many benefits, as described in [project 0](https://cmsc388m.github.io/spring20/project0/build-android/#scripting-backend). Most notably, it can improve performance and make your app run quicker on the device as compared to the Mono scripting backend._
- **XR Settings**
  - _NOTE: Do NOT select any of these options. These refer to Unity's built-in XR platform integrations, which has been deprecated in Unity 2019.3 as they transition over to their new XR plug-in framework that we will be using for this project. Check out [this blog post](https://blogs.unity3d.com/2020/01/24/unity-xr-platform-updates/) for more information on the change._

##### iOS-Specific

If you would like to test your project on an iOS device, you should also make sure to adjust the following settings while the iOS tab is selected in your Player Settings.

- **Other Settings**
  - **Identification**
    - **Bundle Identifier:** com.LastName.FirstName.BarrelBouncer.AR
      - _This is the iOS equivalent of Android's Package Name. It is your app’s unique identifier on your phone (and the App Store, if you submit it there)._
  - **Configuration**
    - **Target minimum iOS Version:** 11.0
      - _This is the earliest version of iOS that supports ARKit._
    - **Requires ARKit Support:** ✓
    - **Architecture:** ARM64
      - _This is the only architecture that the ARKit XR Plugin supports._

#### XR Plugin Management

As you should now be familiar with from project 2, the XR Plugin Management tools are used to install and load the plugins for the XR platforms you would like your application to support. Follow the steps below to add them 

1. Open up the _**Project Settings**_ window by navigating to `Edit` -> `Project Settings` from the menu bar at the top.
2. Click on the _**XR Plugin Management**_ tab on the left sidebar and then click on the _**Install XR Plugin Management**_ button that appears near the center of the window.
3. Make sure that you have the Android tab selected, and then select the checkbox for _**ARCore**_.
4. (Optional) If you would also like to build your application to an iOS device, click on the iOS tab, and then then select the checkbox for _**ARKit**_.

### Installing Packages via the Package Manager

Unity works on a large number of features and tools for a wide, diverse set of use cases. However, not everyone needs all of these tools for every single project. Additionally, the Unity Editor itself is already a fairly large and intensive program to run on computers. As a result, many of these optional features of Unity are moved out of the "core" Unity Editor and are instead accessible as add-on packages for individual projects. These add-on packages are accessible via the Unity Package Manager. To learn more, check out [this blog post about the package manager](https://blogs.unity3d.com/2018/05/04/project-management-is-evolving-unity-package-manager-overview/), [this blog post about packages' life cycles](https://blogs.unity3d.com/2018/05/09/unity-packages-life-cycle/), and [the documentation for the package manager](https://docs.unity3d.com/Manual/Packages.html).

As discussed in the previous section, you will be using Unity's AR Foundation and the XR Interaction Toolkit to complete this project. Since these are optional features provided by Unity, you can install them using the package manager. To open up the _**Package Manager**_ window, navigate to `Window` -> `Package Manager` from the menu bar at the top. Once this is open, you will see a list of available packages in alphabetical order, including some that you already have installed. In fact, when you selected the options to support ARCore and ARKit from the XR Plugin Management tool, it installed the _**ARCore XR Plugin**_ and the _**ARKit XR Plugin**_ for you behind the scenes. Additionally, if you scroll all the way down to the bottom, you will see that even the _**XR Plugin Management**_ tool itself is a package that you installed.

#### The Development Frameworks

You can now move on to installing the development tools. First, install the latest stable version of the _**AR Foundation**_ framework (`3.0.1` as of this writing). Next, install the package for the _**XR Interaction Toolkit**_. Note that the _**XR Interaction Toolkit**_ is still in preview, so it won't show up in the package manager by default. In order to get around this, click on the _**Advanced**_ button near at the top of the _**Package Manager**_ window and select the option for _**Show Preview Packages**_.

#### Face Tracking

If you are going to be testing on an iOS device, you should also install the latest stable version of the _**ARKit Face Tracking**_ package (`3.0.1` as of this writing). You may be wondering why there's two separate ARKit packages or why we aren't importing a "Face Tracking" package for ARCore, especially since we'll be using face tracking in this project to capture reactions to your score. Unity explains the reasoning behind this as follows:

- _Apple's App Store will reject an app that contains certain face tracking-related symbols in its binary if the app developer does not intend to use face tracking, so we've broken out face tracking support into a separate package to avoid any ambiguity._ - [Source](https://docs.unity3d.com/Packages/com.unity.xr.arkit@3.0/manual/index.html)

Google does not have this restriction on the Play Store, hence why there is just a single ARCore XR Plugin for that contains all of the supported ARCore features, including face tracking.

Another difference between the two AR platforms is that Apple only supports face tracking functionalities on devices with a TrueDepth camera (i.e. devices that have Face ID). This ensures that AR experiences using your face are of a much better quality and have much better accuracy, but on the flip side it requires you to have a newer phone to test this out. Google, on the other hand, allows face tracking on pretty much all ARCore-supported Android devices, as long as it has a front-facing camera. This may mean that the experience may not be as precise, but it gives the capability to a much larger portfolio of devices.

### Closing Notes

Congrats! You have now configured your project and are ready to begin AR development in Unity!

## [Previous Section](../tools) | [Go Home](..) | [Next Section](../ar-scene)
