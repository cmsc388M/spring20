# Project 3: Barrel Bouncer AR Edition

## Part 6: Adjusting for Environmental Lighting

As we discussed in class (and as you saw in the AR Best Design Practices Activity), it is important to consider the lighting attributes of the real-world environment when creating an AR app as it makes the virtual objects fit-in better and feel more realistic. This is because the simulated lighting would hit them in the same way real lighting would, and this would also provide shadows in the correct direction.

The underlying ARCore and ARKit platforms can analyze each individual image that is captured by the device in order to predict properties of the lighting in the real world. AR Foundation provides access to much of this light estimation data if available, including values for brightness, color temperature, and color correction, which you can then use to manipulate properties of the _**Light**_ component on the _**Directional Light**_ GameObject in your scene. It also gives you the main direction that the light is facing. This means that you can appropriately set the _**Directional Light**_'s Transform's rotations to match this. Note that you do not need to adjust the position of the directional light, since directional light originates from the skybox anyway (and thus its position does not affect any lighting-related calculations).

For this subsection, you will use a script to gather the four aforementioned lighting properties (brightness, color temperature, color correction, and main direction) and then apply them to the light in your scene each time your phone's camera receives new data. As part of the unitypackage, we have already provided you with a starter script called _**Light Estimation**_. It contains a function called `ChangeLighting` which is subscribed to the camera manager's `frameReceived` event. It is inside this function where all of your code for modifying the _**Directional Light**_'s properties must go (i.e. you cannot add any helper methods or outside fields). Before you do so, complete the following setup:

1. On your _**AR Camera**_ GameObject, find the _**AR Camera Manager**_ component and change its _**Light Estimation Mode**_ setting to _**Ambient Intensity**_.
2. Add the _**Lighting Estimation**_ script onto your _**Directional Light**_ GameObject.
3. In the slot for the _**Camera Manager**_ property, drag in the reference to your _**AR Camera**_'s _**AR Camera Manager**_ component.
4. In the slot for the _**Light**_ property, drag in the reference to your _**Direction Light**_'s _**Light**_ component.
5. Open up the script in your favorite code editor and write up your implementation for the `ChangeLighting` method. Make sure to check if each piece of data is actually available before actually assigning it to the _**Light**_'s properties.

Note that you may find the documentation for [ARCameraFrameEventArgs](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.0/api/UnityEngine.XR.ARFoundation.ARCameraFrameEventArgs.html), [ARLightEstimationData](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@4.0/api/UnityEngine.XR.ARFoundation.ARLightEstimationData.html), and [Light](https://docs.unity3d.com/ScriptReference/Light.html) helpful for this part of the project, as well as the Lighting Estimation scene from the AR Foundation samples that we described in [Part 0](../tools/#resources-and-examples).

## [Previous Section](../occlusion) | [Go Home](..) | [Next Section](../phone-uis)
