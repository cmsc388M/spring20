# Project 1B: Barrel Bouncer (Interactions)

## Part 5: Adding Feedback with 3D Sound Effects

In the final part of this project, you will be adding sound effects to some of the interactions that are already taking place between the GameObjects.

### Notes on Importing and Playing Sound Files

We have provided three `.wav` files with this project ([here](https://github.com/cmsc388M/spring20/tree/master/project1b/)). Download these files and drag them into your project window in the Unity Editor. They will be imported as AudioClips. There are then a few ways to play a sound:

1. You can define an AudioSource component on a GameObject. Some fields of interest are the reference to the AudioClip asset, the spatial blend (which can be set to 3D), and the Play on Awake bool, which starts the sound as soon as the GameObject is created. Like almost any other component on a GameObject, the AudioSource uses the Transform to determine its current position so that it knows where the sound should be coming from.
2. You can use the static method [AudioSource.PlayClipAtPoint](https://docs.unity3d.com/ScriptReference/AudioSource.PlayClipAtPoint.html) for playing an AudioClip in 3D space at a single specified given point.

### Sound-Related Functionality

Below are some sound-related tasks that you should implement. Note that the sounds should **only** be played at the specified times and locations.

- When a ball is first launched (i.e. right after it leaves your hand), the _**Woosh**_ sound should be played. This sound should eminate from the ball and should continue to follow the ball's motion until its completion.
- When a ball hits a barrel, the _**Explode**_ sound should be played. This sound should come from the center of the barrel, regardless of where the ball hit the barrel or where it moves afterwards.
- When a ball hits your environment (or any other non-barrel element of your environment), the _**Bounce**_ sound should be played. This sound should come from the point of the collision, and should not follow the ball's movement.

## [Previous Section](../throw-balls) | [Go Home](..) | [Next Section](../submission)
