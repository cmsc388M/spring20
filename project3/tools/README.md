# Project 3: Barrel Bouncer AR Edition

## Part 0: A Look Into Unity's AR Tools

### The History of Modern Handheld AR Development

A few years ago, Apple and Google introduced ARKit and ARCore, new platforms for building augmented reality experiences for iOS and Android, their respective mobile operating systems. Both ARKit and ARCore had their own SDKs that allowed developers to take advantage of the platform's features. They did many of the same things, however, creating an AR app for both platforms meant that you had to have two different codebases and deal with two different SDKs. AR Foundation is Unity's cross-platform augmented reality API that aims to solve this problem. The API essentially serves as a wrapper to the equivalent functions in the ARKit and ARCore SDKs so that you can have a single codebase for your AR apps. It supports both smartphone platforms, and has also recently added support for wearable AR platforms as well (like the HoloLens and Magic Leap). Below is an image that summarizes what AR Foundation does.

![Image showing overview of AR Foundation](https://blogs.unity3d.com/wp-content/uploads/2018/12/image4-1.png)

To learn more about AR Foundation, check out [the product page](https://unity.com/unity/features/arfoundation) and [this blog post](https://blogs.unity3d.com/2018/12/18/unitys-handheld-ar-ecosystem-ar-foundation-arcore-and-arkit/).

### The Unity XR Tech Stack

AR Foundation is just one small part of the new Unity XR Tech Stack, built on top of their new XR plug-in architecture that you learned about in project 2. This new tech stack was created specifically to make it easier to develop cross-platform XR experiences using Unity’s own tools, as Unity has taken years of developer feedback into account when designing it. The image below shows a quick architectural summary of this new XR Tech Stack.

![Image showing Unity's new XR Tech Stack](https://docs.unity3d.com/2019.3/Documentation/uploads/Main/unity-xr-tech-stack.png)

Looking at this diagram, you may notice that there are three particular developer tools that lead up to an AR app. We have already explained what AR Foundation is above, so we will now discuss the other two tools.

#### XR Interaction Toolkit

The XR Interaction Toolkit is a cross-platform development tool that provides a set of ready-to-use components that enable common UX interactions without the need to write your own custom code or use vendor-specific SDKs. In the context of VR development, this may involve stuff like teleportation and world-space UI interaction. In the context of AR development, it may involve stuff like object placement, selection, and rotation through finger-based gestures (like tap, drag, pinch, etc.), similar to what you saw in the AR Best Design Practices Activity.

To provide an example of how this makes development easier, let us consider this very same Barrel Bouncer AR project. Last semester, this toolkit did not exist, and as a result, students had to write their own code to Raycast onto the real world based on the touch input and instantiate the barrels if the Raycast intersected with a plane (i.e. they tapped on a plane on their phone's screen). Now, you simply have to add and set up the components already provided to you by the XR Interaction Toolkit in order to accomplish this same functionality. Needless to say, we will be using it for this project.

The XR Interaction Toolkit is currently in a public preview. You can read more about it at [this blog post](https://blogs.unity3d.com/2019/12/17/xr-interaction-toolkit-preview-package-is-here/).

#### Mixed and Augmented Reality Studio (MARS)

One of the largest problems with AR/MR development is that you cannot test it in the Unity Editor simply by clicking the play button and instead need to generate a build and install it on an AR-compatible device for testing. This is a very inefficient process as you need to generate a build every single time you want to test something, even if you just made a small change. With Project MARS, Unity aims to solve this problem.

MARS contains a simulation view inside the Unity Editor, which you can use to simulate an AR device moving around in a realistic environment. They have a couple of pre-built environments for testing, like a living room and a kitchen. You can even use the MARS companion app for your phone to scan your real-world environment and import it into the Simulation View so you can more easily debug problems that are occurring within your specific environment.

MARS also aims to add on some additional features to help improve your app's understanding of the environment. This involves stuff like tagging objects in the real world by their identification (i.e. dog, cat, etc.) and by their properties (i.e. wooden, grassy, etc.) so that you can use these to create more robust AR experiences.

Unfortunately, MARS is currently in a closed alpha and is not available to the public at this time. As a result, we will not be using it in our project.

To learn more about MARS, check out [the product page](https://unity.com/unity/features/mars) and [this blog post](https://blogs.unity3d.com/2019/10/02/labs-spotlight-project-mars/).

### Resources and Examples

In this project you will be making use of both the AR Foundation framework and the XR Interaction Toolkit described above. As a result, we strongly recommend you bookmark the documentation links below, download the example projects below, and open them up in the Unity Editor to use a reference on how to accomplish various tasks as you work through this project.

**AR Foundation**

- [Documentation](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@latest/)
- [Examples](https://github.com/Unity-Technologies/arfoundation-samples)

**XR Interaction Toolkit**

- [Documentation](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@latest/)
- [Examples](https://github.com/Unity-Technologies/XR-Interaction-Toolkit-Examples)

## [Go Home](..) | [Next Section](../setup)
