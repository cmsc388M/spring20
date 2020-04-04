# Project 2: Barrel Bouncer VR Edition

## Part 6: A More Realistic Spatial Audio Experience

Unity's default audio spatializer is fairly limited in its capabilities: it only considers the volume and position of the sound when making its calculations of how the sound should appear to each ear. As we discussed in class, however, sound can be affected by a variety of factors, like the medium it travels through (air, wind, snow, water, etc.) and the objects it passes through or reflects off of (walls, ground, barrels, etc.). Accounting for these audio cues can greatly affect elevate the level of immersion of a virtual experience, and as such many XR device vendors have created their own spatial audio tools and SDKs, such as the [Microsoft Spatializer](https://github.com/microsoft/spatialaudio-unity), Google's [Resonance Audio SDK](https://resonance-audio.github.io/resonance-audio/), and the [Oculus Audio Tools](https://developer.oculus.com/documentation/unity/unity-audio/). In this section, you will be modifying your project to make use of the Oculus Audio Tools, specifically the [Oculus Native Spatializer Plugin for Unity](https://developer.oculus.com/documentation/unity/audio-osp-unity/) (ONSP). The ONSP is already included as part of the Oculus Integration.

### Resources and Examples

Below are some resources that you may find helpful to reference as you work through this section:

- The Oculus Documentation for the ONSP (found [here](https://developer.oculus.com/documentation/unity/audio-osp-unity/)).
- The spatial-audio-related sample scenes included with the Oculus Integration. Note that you can play and test these scenes within the Unity Editor without an actual VR headset. However, you should perform the project setup described below before doing so. It is also recommended that you use earphones while testing out these samples.
  - The _**RedBallGreenBall**_ sample scene provides a simple introduction to OSNP resources and examples of how what the spatializer sounds like. It is located in `Assets` -> `Oculus` -> `Spatializer` -> `scenes` and its documentation can be found [here](https://developer.oculus.com/documentation/unity/audio-osp-unity-scene/). 
  - The _**Test**_ sample scene demonstrates how to use the Oculus Audio Manager for sound effect management. It is located in `Assets` -> `Oculus` -> `AudioManager` -> `Scenes` and its documentation can be found [here](https://developer.oculus.com/documentation/unity/audio-osp-unity-audiomanager/). 
- [This Unity Learn tutorial](https://learn.unity.com/tutorial/unit-7-sound-in-vr) on how to use the Oculus Spatializer in Unity, lead by a spatial audio tech lead and manager at Oculus. His videos go over many of the tasks you will be asked to complete in this section as well as the concepts behind them and some spatial audio best practices.

### Project Setup

Open up the Project Settings window (the same one you worked with in [Part 1](../setup)), click on the _**Audio**_ tab, and apply the following settings:

- **Spatializer Plugin:** OculusSpatializer
- **Default Speaker Mode:** Stereo
  - You set this to stereo because the VR headsets are like earphones; they use two speakers (one for each ear).
- **DSP Buffer Size:** Best Latency
  - This settting helps reduce any sound-related lag, which is critical in an immersive VR setup, especially since the user can rotate their head very fast.

### Modeling Your Environment's Acoustics

Even though you have set up your project to support the Oculus Spatializer, it doesn't understand the layout of your environment nor the audio reflective properties of each surface. There are two parts to setting this up. First, you will first need to create a simple reflection model based on a rectangular prism "shoebox". Then, you will apply dynamic room modeling which further updates this model based on the objects within the current space as well as the user's location within the space.

To set up the basic shoebox, follow the steps below:

1. From the menu bar, click on `Assets` -> `Create` -> `Audio Mixer`. Rename it if you would like. Then double click on it to open up the Audio Mixer window.
2. In the main space of the Audio Mixer window, click on the _**Master**_ group. Once it is selected, go to the Inspector window and click on the _**Add Effect**_ button. Then, select the _**OculusSpatializerReflection**_ effect.
3. Modify the following properties for the _**OculusSpatilaizerReflection**_ effect you added:
   - Select _**Enable Early Reflections**_. Early reflections describe how the sounds reflect off the first few objects it hits.
   - Select _**Enable Reverbation**_. Late reverbations describe how the sounds ring out or echo through the environment after its first few bounces.
   - Adjust the _**Room Dimensions**_ to roughly match those of the environment. If you have a large, open, outdoor environment, you may want to have very large dimensions. On the other hand, if you have an indoor environment, you will want to set it to the dimensions of a typical room in your scene.
   - Adjust the _**Wall Reflection Coefficients**_ to define how much reflection each side of the cube should have. A value of 0 absorbs all sounds that hit it, whereas a value of 1 would perfectly reflect all sounds.
4. Create an empty GameObject in your scene and name it "Audio Manager". Make sure it is positioned at origin and then set the GameObject to be static.
5. Add the _**Audio Manager**_ component to your _**Audio Manager**_ GameObject. Then, set its _**Master Audio Mixer**_ property to the audio mixer you created.

While the shoebox model is a great first step towards making audio sound more natural, it has numerous limitations. For one, it doesn't consider any of the other props or items in the environment and thus only acts like a bare room. Additionally, the shoebox is always centered at the user's head. This means that if a user is close to one of the walls of the room in their actual environment, the audio won't actually feel like its bouncing off that wall. Luckily, the Oculus Spatializer provides dynamic room modeling functionality, which uses Raycasting in different directions to fine-tune the shoebox model, estimate your position within the room, and generate other spatial audio reflection points on other items and obstacles in your environment. To set up this functionality, simply add the _**Oculus Spatializer Unity**_ component to your _**Audio Manager**_ GameObject. You can leave all its properties set to their default values. If you want to learn more about how it works, check out the documentation [here](https://developer.oculus.com/documentation/unity/audio-osp-unity-dynroom/).

### Spatializing Individual Sounds

Each of the individual sounds must also be correctly set up to make use of the ONSP.

#### 3D Audio Positioning

Before we begin, it may be worth revisiting the discussion of the importance of positioning in 3D spatial audio. If you think about the real world, clapping comes from your hands, words come out of your mouth, and stomping comes from the contact between your foot and the floor. It doesn't make sense for those sounds to be coming from somewhere else in a virtual environment either, like the center of your body, a meter in front of your head, etc. As a result, for this subsection you should verify that all the sounds for Barrel Bouncer are eminating from the precisely specified location. We've copied over [the relevant part of the project 1B description](../../project1b/3d-sound/#sound-related-functionality) below for your reference.

- When a ball is first launched (i.e. right after it leaves your hand), the _**Woosh**_ sound should be played. This sound should eminate from the ball and should continue to follow the ball's motion until its completion.
- When a ball hits a barrel, the _**Explode**_ sound should be played. This sound should come from the center of the barrel, regardless of where the ball hit the barrel or where it moves afterwards.
- When a ball hits your environment (or any other non-barrel element of your environment), the _**Bounce**_ sound should be played. This sound should come from the point of the collision, and should not follow the ball's movement.

#### Migrating Your Implementation to ONSP

As you may recall from project 1B, there are two ways you could have played spatial audio within your scene: by attaching an _**AudioSource**_ component to your GameObject and by using the static `AudioSource.PlayClipAtPoint()` method. Each of these will have their own set of steps for configuring the audio to make use of the ONSP. For this subsection, you should enable the usage of ONSP for all audio playback in the scene.

##### From AudioSource Component on GameObject

For audio that originates from an _**Audio Source**_ component on a GameObject, the migration simply involves adding an additional component and adjusting certain properties. This means that you can continue playing audio from this Audio Source in the same way as before, whether that's with _**Play On Awake**_ or with the Audio Source's `Play()` method, once you have completed the following steps:

1. On your _**Audio Source**_ component, set the _**Output**_ property to the _**Master**_ Audio Mixer Group of the Audio Mixer you created. This will allow it to make use of the environmental acoustics model you defined above.
2. On the same GameObject that you _**Audio Source**_ is attached to, add the _**ONSP Audio Source**_ component. This will handle the custom HRTF processing.
3. Tweak the following properties of the _**ONSP Audio Source**_ as necessary to make each sound feel more realistic:
   - **Spatialization Enabled:** ✓
     - This will allow the sound to be spatialized in 3D space.
   - **Reflections Enabled:** ✓
     - This will enable early reflections and late reverbations for the sound, the effects of which will be determined by the model you created above.
   - **Oculus Attenuation:** ✓
     - Attenuation refers to a loss of energy. In acoustics, this typically means a reduction in volume. Oculus has created a more physcially accurate attenuation model than Unity's default volume curve and uses the range parameters described below to calculate the sound's volume at your location.
   - **Range**
     - If necessary, adjust these values to form a more realistic effect. The minimum value defines the distance at which no attenuation, or reduction in volume, is applied, and the maximum value detefines the distance at which the sound becomes silent.
   - **Gain**
     - If necessary, you can use this to increase the overall volume of the sound.
   - **Reverb Send Level**
     - If necessary, you can use this to fine-tune the impact of reverb on a per-sound basis. A very reverberant sound will sound like it is far off in the distance, even if it's loud. Similarly, a sound with very little reverb will sound like it is close to you, even if it is quiet.

##### From AudioSource.PlayClipAtPoint Method in Script

For audio that was played at a specified point using this static method, you will need to create sound effects in the Audio Manager to modify their spatial audio properties and then replace the fields and methods in your scripts with the SoundFX equivalents.

1. Go to the _**Audio Manager**_ component of your _**Audio Manager**_ GameObject and click the _**+**_ button under _**Sound FX Groups**_ box to add a new sound effects group. Then, name the sound FX group and hit the Enter key.
2. Select the sound FX group so that the _**Properties**_ and _**Sound Effects**_ options for that group appears.
3. Under the _**Sound Effects**_ box, click on the _**Add FX**_ button to add a new effect.
4. Expand your newly created sound effect and modify the following properties:
   - Give the sound effect the same name as the sound.
   - Select the following properties: _**Enable Spatialization**_, _**Reflections Enabled**_, and _**Enable Oculus Atten.**_. Note that the latter two options will only show up once spatialization is enabled. For information on what these properties do, see the steps from the Audio Source migration [above](#from-audiosource-component-on-gameobject).
   - If necessary, adjust the gain and range for a more realistic effect. Once again, see the steps from the Audio Source migration for more info on how these properties affect the sound.
   - Expand the _**Sound Clips**_ array and drag in the appropriate _**Audio Clip**_ from your project window.
5. To add an additional sound effect to the same sound FX group, collapse the properties of the current sound effect and repeat steps 3 & 4.
6. In your script(s), replace the _**AudioClip**_ fields with _**SoundFX**_ fields and the `AudioSource.PlayClipAtPoint()` method with the sound effect's `PlaySoundAt()` method. Then use the inspector to assign the specific sound effect you defined in your Audio Manager. Additionally, note that the `PlaySoundAt` takes in a single Vector3 representing the position to play the sound at and unlike the `PlayClipAtPoint` method, it is not static. An example showing its usage is provided below.

###### Example

Let's say you had a script on a GameObject that had a method to play an audio clip at its current position in space. Your code may have looked like this:

``` csharp
public AudioClip exampleSoundEffect;

private void SomeMethod()
{
    AudioSource.PlayClipAtPoint(exampleSoundEffect, transform.position);
}
```

After you've completed the steps above to take advantage of the ONSP, your code would now look like the code snippet below.

``` csharp
public SoundFXRef exampleSoundEffect;

private void SomeMethod()
{
    exampleSoundEffect.PlaySoundAt(transform.position);
}
```

### Bonus Task (Optional)

Utilize the tools you've learned about above to create a hidden sound; in other words a sound that is not in your direct path but is enclosed within another object. In the [tutorial linked above](#resources-and-examples), they use an example of a creepy ambiance coming from another room that you can hear from behind a closed door. Another example could be hiding the sound of the ocean inside a seashell on the beach. Whatever you choose, it should make sense in the context of your environment. 

## [Previous Section](../ui) | [Go Home](..) | [Next Section](../submission)
