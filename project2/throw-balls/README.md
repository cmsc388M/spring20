# Project 2: Barrel Bouncer VR Edition

## Part 4: Throwing Balls with Motion Controllers

When designing virtual reality experiences, it is important to think about how you can increase immersion. One great way to do this is by using the motion controllers for intuitive hand and arm gestures. These can be a lot more immersive than simply clicking buttons, pressing keys, or moving a mouse. As a result, for this project, you will be using the Oculus Integration's grabbing system to pick up the balls and then using swinging arm gestures to actually throw the ball, as shown below:

![GIF showing how you can throw balls with motion controllers](images/throw-ball.gif)

### Example Scene

The Oculus Integration actually has two grabbing systems: a regular grabbing system (to pick up objects that your hands/controllers come directly in contact with) and a distance grabbing system (to point at and pick up objects at a distance). Since we want to directly reach into the bucket to pick up the balls, we will be using the former. Unfortunately, the Oculus Sample Framework does not provide a sample scene that shows how to use the regular grabbing system, but it does contain a scene called "DistanceGrab" that shows how to use the distance grabbing system. This scene can be found in the same folder as the other samples (`Assets` -> `Oculus` -> `SampleFramework` -> `Usage`). It may still be useful for you to reference this scene as you work on this section as it contains a somewhat similar setup and set of properties with its associated components. The documentation that explains how the scene works can be found [here](https://developer.oculus.com/documentation/unity/unity-sf-distancegrab/).

### Configuring the Controllers as "Grabbers"

The Oculus Integration allows you to designate certain GameObjects as "grabbers", which are then allowed to grab certain "grabbable" GameObjects. Since the user should be able to pick things up with the touch controllers, you should apply the following changes to both the left and right instances of the _**OVRControllerPrefab**_ in your scene:

1. Add a _**Sphere Collider**_ with a radius of 0.1 meters, since this is roughly is roughly the size of the model of the Oculus Touch controller. The Oculus Integration's grabbing system relies on Unity's physics system to detect if grabber and grabbable objects are in contact with each other, and thus you need colliders on both types of GameObjects.
2. Make the collider a trigger, so that 1) the motion of the model accurately follows the real controller movements and is not restricted or messed up by collisions, and 2) you can actually move your controller into the ball without pushing it away.
3. Add the _**OVR Grabber**_ script that is provided by the Oculus Integration. Note that this will also automatically attach a _**Rigidbody**_, which the script depends upon.
4. Set the _**Rigidbody**_ to not use gravity so that the controller models don't automatically fall to the floor.
5. Assign the correct values for the _**OVR Grabber**_'s correct component properties and references, as listed below:
  - Set the _**Parent Held Object**_ property to true. This will make the grabbed object a child of the grabber when it is picked up, thus allowing it to follow the movements of the controller. It will also automatically set the object's parent to be null once you release it, so that its motion is not constrained relative to other GameObjects.
  - Assign the _**Grip Transform**_ to the transform of the instance of the _**OVRControllerPrefab**_. This defines the position to move the grabbable object to once it has been grabbed. In other words, when a ball is grabbed, it will be moved to the same location as the _**OVRControllerPrefab**_ GameObject at that point in time.
  - The _**Grab Volumes**_ define the colliders that should be used by the grabber to detect if it has collided with any grabbable GameObjects. Increase the array size to 1 and set it to the sphere collider of the instance of the _**OVRControllerPrefab**_ that you added above in step 1.
  - Select either "L Touch" or "R Touch" for the _**Controller**_ type, depending on which controller you are currently dealing with.

Note that you do not need to set references for any other properties for the reasons listed below:

- If the _**Parent Transform**_ is not assigned, then the _**OVR Grabber**_ script automatically assigns this property at runtime to the transform of the parent GameObject of the GameObject it is attached to.
- Assigning the _**Player**_ reference allows the grabber to set collisions between the grabber's _**Grab Volumes**_ and the colliders on the player (and its descendants) to be ignored by the Physics system. However, since our bucket and balls are descendants of our Player (the _**OVRCameraRig**_), setting this property would mean that the grabber would not be able to detect when it has collided with the balls and thus won't be able to pick them up (which is definitely not what we want). Leaving this property unassigned will not have any adverse effects on your scene, since the developers at Oculus appropriately implemented null checks before accessing and working with this reference.

### Making the Balls Grabbable

All you need to do make the balls grabbable is add the _**OVR Grabbable**_ script to them, which is provided by the Oculus Integration. Once you do this, you should be automatically be able to pick up and throw the balls when you build the app. However, we also want you to add some custom functionality based on the grabbing events. Specifically, we want:

- a short haptic vibration on the controller to provide feedback to the user that the ball has been picked up.
- start playing the _**Woosh**_ sound once the ball is thrown.
- set the ball to be destroyed 5 seconds after it's been thrown.

As a result, you should NOT have the _**OVR Grabbable**_ script on your balls but should instead add your own custom script to it that extends the _**OVRGrabbable**_ class instead of _**MonoBehaviour**_. Note that you can still use all the regular Unity events in the scripting lifecycle (like Update, OnCollisionXXX, etc.) since _**OVRGrabbable**_ is a component after all, which means it does extend MonoBehaviour somewhere up the chain of inheritance. If you already have a script on your balls, you may choose to change the class that it extends from rather than creating a new script from scratch.

The `GrabBegin` and `GrabEnd` methods of the _**OVRGrabbable**_ class are automatically called when the GameObject has just been picked up or been let go of. You can override these methods in order to implement your custom functionalities once they are called. Make sure to call the superclass's version of the method before adding the additional functionality. Below is an example of the syntax you should use to override the `GrabBegin` method. To override the `GrabEnd` method, you should look through the _**OVRGrabbable**_ class to determine the correct signature to use yourself.

``` csharp
public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
{
    base.GrabBegin(hand, grabPoint);
    // Your custom functionality here.
}
```

Check out [this piece of Oculus Documentation](https://developer.oculus.com/documentation/unity/unity-haptics/) to determine how you can enable vibration. Below are a few things you should keep in mind as you implement the vibration feedback functionality:

- The method you use to achieve this doesn't account for the duration of the vibration. By default, the vibration last for 2 seconds, which is a bit too long for our purposes of providing a quick feedback. A good way to get around this would be to turn the vibration on, wait for a short period of time (like 0.25 seconds), and then turn the vibration off.
- The haptic feedback should occur on the same controller that was used to pick up the ball (e.g. if the user picks up a ball with their left hand, the left controller should vibrate).

Your code for playing the _**Woosh**_ sound and setting the ball to be destroyed in 5 seconds can be placed within the `GrabEnd` method, since that is the start of when your ball has actually been "thrown". Additionally, if you had set the _**Rigidbody**_ to be kinematic in [Part 2](../environment-mods/#creating-a-bucket-of-balls), you should also manually turn that off within the `GrabEnd` method so that the ball reacts to physics again once it has been thrown.

### Bonus Task (Optional)

- The Oculus Quest also supports hand tracking, which allows you to use your hands to engage with and manipulate virtual objects without having to use a controller, as shown in [this promo video](https://youtu.be/2VkO-Kc3vks). Go ahead and modify your project to support hand tracking so that the user can pick up the balls with their hands in the same way they would in real life. Note that your project should have support for both motion controllers and hand tracking. If the user is using controllers, then the _**OVRControllerPrefab**_ should be shown. If the user is using their hands for interaction, then the _**OVRHandPrefab**_ should be shown. The Oculus Sample Framework contains an example scene called "HandsInteractionTrainScene" which shows you how to use hand tracking. The documentation for that scene can be found [here](https://developer.oculus.com/documentation/unity/unity-sf-handtracking/).

## [Previous Section](../locomotion) | [Go Home](..) | [Next Section](../ui)
