# Project 2: Barrel Bouncer VR Edition

## Part 6: A More Realistic Spatial Audio Experience

Unity's default audio spatializer is fairly limited in its capabilities: it only considers the volume and position of the sound when making its calculations of how the sound should appear to each ear. As we discussed in class, however, sound can be affected by a variety of factors, like the medium it travels through (air, wind, snow, water, etc.) and the objects it passes through or reflects off of (walls, ground, barrels, etc.). Accounting for these audio cues can greatly affect elevate the level of immersion of a virtual experience, and as such many XR device vendors have created their own spatial audio tools and SDKs, such as the [Microsoft Spatializer](https://github.com/microsoft/spatialaudio-unity), Google's [Resonance Audio SDK](https://resonance-audio.github.io/resonance-audio/), and the [Oculus Audio Tools](https://developer.oculus.com/documentation/unity/unity-audio/). In this section, you will be modifying your project to make use of the Oculus Audio Tools, specifically the [Oculus Native Spatializer Plugin for Unity](https://developer.oculus.com/documentation/unity/audio-osp-unity/) (ONSP). The ONSP is already included as part of the Oculus Integration.

### Resources and Examples

Below are some resources that you may find helpful to reference as you work through this section:

- The Oculus Documentation for the ONSP (found [here](https://developer.oculus.com/documentation/unity/audio-osp-unity/)).
- The _**RedBallGreenBall**_ sample scene included with the Oculus Integration (located in `Assets` -> `Oculus` -> `Spatializer` -> `scenes`). The documentation for the scene can be found [here](https://developer.oculus.com/documentation/unity/audio-osp-unity-scene/). Note that you can play and test this scene within the Unity Editor without an actual VR headset. However, you should perform the setup described below before doing so. It is also recommended that you use earphones while testing out this sample.
- [This Unity Learn tutorial](https://learn.unity.com/tutorial/unit-7-sound-in-vr) on how to use the Oculus Spatializer in Unity, lead by a spatial audio tech lead and manager at Oculus. His videos go over pretty much all the tasks you will be asked to complete in this section as well as many of the best practices and concepts behind them.

### Project Setup

Open up the Project Settings window (the same one you worked with in [Part 1](../setup)), click on the _**Audio**_ tab, and apply the following settings:

- **Spatializer Plugin:** OculusSpatializer
- **Default Speaker Mode:** Stereo
  - You set this to stereo because the VR headsets are like earphones; they use two speakers (one for each ear).
- **DSP Buffer Size:** Best Latency
  - This settting helps reduce any sound-related lag, which is critical in an immersive VR setup, especially since the user can rotate their head very fast.

### Modeling Your Environment's Acoustics

Coming soon...

### Spatializing Individual Sounds

Coming soon...

### Adding a Hidden Sound

The final task for this section is to utilize the tools you've learned about above to create a hidden sound; in other words a sound that is not in your direct path but is enclosed within another object. In the [tutorial linked above](#resources-and-examples), they use an example of a creepy ambiance coming from another room that you can hear from behind a closed door. Another example could be hiding the sound of the ocean inside a seashell on the beach. Whatever you choose, it should make sense in the context of your environment. 

## [Previous Section](../ui) | [Go Home](..) | [Next Section](../submission)
