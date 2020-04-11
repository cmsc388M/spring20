# Project 3: Barrel Bouncer AR Edition

## Part 2: Creating Your First AR Scene

Since you are now developing an AR app, you are dealing with your real-world environment, not the virtual world you created in project 1A. Thus, you should start fresh with a new scene since there is a lot going on in the old one. Go ahead and create a new scene. Then, delete the _**Main Camera**_ gameobject that was automatically added to your scene. You will not need this, since you will add another camera during the setup process that already has the settings and components required for AR applied to it.

Next, go to the menu bar, navigate to `GameObject` -> `XR`, and add an _**AR Session**_ and an _**AR Session Origin**_ to your scene.

The _**AR Session**_ gameobject contains two components:

- [AR Session](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.0/manual/index.html#arsession)
  - This component controls the lifecycle of an AR experience (i.e. enabling and disabling AR tracking) and keeps track of the current state of the session (i.e. whether the device is supported, if AR software is being installed, whether the session is working, etc.).
- [AR Input Manager](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.0/manual/index.html#ar-input-manager)
  - This component is necessary for enabling world tracking.

The _**AR Session Origin**_ gameobject contains a single component called [AR Session Origin](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.0/manual/index.html#ar-session-origin), whose purpose is to transform trackable features (such as planar surfaces and feature points) into their final position, orientation, and scale in the Unity scene. By default, the origin (coordinate <0,0,0>) of the coordinate system is set based on the initial location of your phone at the beginning of the current AR Session.

The _**AR Session Origin**_ gameobject also includes a single child gameobject called _**AR Camera**_, which contains three additional components (in addition to the default Camera component):

- [AR Pose Driver](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.0/manual/index.html#ar-pose-driver)
  - This component drives the camera's local position and rotation according to the device's tracking information, which allows the camera's local space to match the AR "session space".
- [AR Camera Manager](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.0/manual/index.html#ar-camera-manager)
  - This script enables camera features, such as textures representing the video feed and controls light estimation modes.
- [AR Camera Background](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.0/manual/index.html#ar-camera-background)
  - This component takes your phone's camera feed and applies it to the app's background each frame, essentially enabling you to see the image that the camera is currently capturing on your phone's screen.

You should also label the _**AR Camera**_ GameObject with the tag _**MainCamera**_.

At this point, if you build and test your app on your phone, you should be able to see the camera stream.

## [Previous Section](../configuration) | [Go Home](..) | [Next Section](../plane-detection)
