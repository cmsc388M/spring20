# Project 1B: Barrel Bouncer (Interactions)

## Part 3: Spawning Barrels Into Your Scene

In this section, you will be implementing functionality where you spawn a barrel at a raycasted point when you right-click on your mouse.

### Creating the Barrel Prefab

To complete the setup for this section, follow these steps:

- Find a model of a barrel and import it into your project. You may do so using any of the methods described in project 1A (i.e. Asset Store or online sources), as described [here](https://cmsc388m.github.io/spring20/project1a/import-models/).
- Add a Collider and Rigidbody to the barrel if it doesn't already have these components in order to make it a physical object that is affected by physics and gravity.
- Scale your barrel so it is of an appropriate and realistic size, if necessary.
- Make this barrel into a prefab (or apply the changes to an existing prefab) and remove any instances of the barrel from your scene.

### Writing the Script

In your player controller, you should define a public reference to the barrel prefab and implement the following functionality:

- When the right-click is pressed on your mouse, you should raycast out from the center of your camera view (see the [Physics.RayCast](https://docs.unity3d.com/ScriptReference/Physics.Raycast.html) method).
- If the ray intersected with a Collider on a GameObject in your scene, you should spawn a new barrel in an upright orientation at a position where its base is 1 meter above the hit position, so that the barrel then falls down onto that position. See the documentation for [GameObject.Instantiate](https://docs.unity3d.com/ScriptReference/Object.Instantiate.html).

## [Previous Section](../player-controller) | [Go Home](..) | [Next Section](../throw-balls)
