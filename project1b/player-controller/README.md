# Project 1B: Barrel Bouncer (Interactions)

## Part 2: Creating a More Realistic Player Controller

In class, we looked at some of the inheritent problems with using Transform methods to apply movement to a player when it has a Rigidbody and is affected by physics. In this section, you will be revising your player controller to take advantage of the Rigidbody properties and methods and also implement a few new aspects of physics-related functionality.

### Setup

There are a few changes we will want to make to our player GameObject, as follows:

- We originally created a capsule to represent our player's body. However, we don't really care about its visual representation in the scene, since we can't see it ourselves anyway, and are only really interested in its capsule collider so that the player can react to the physics system. As a result, you should remove the mesh filter and mesh renderer components of the Player.
- Add a Rigidbody to the Player GameObject so that it is unable to move through other GameObjects affected by the physics system.
- By default, the hemispherical shape of the bottom of the capsule collider used along with the Rigidbody could make the Player topple over as they try to move. In order to prevent this, you may need to restrict rotational movement along certain axes in the Rigidbodies' properties.
- You should create a new empty GameObject as a child GameObject of the Player and rename it to _"Feet"_. Then, set its local position to <0, -1, 0>. This will place its pivot right at the bottom of the capsule.
- Create a box collider on the feet of size <0.3, 0.05, 0.3> and with a center of position <0, 0.025, 0>. This creates the collider right at the "feet" of the capsule. Mark it as a trigger, since we don't actually want it to collide with and be affected by the physics system; we just want to use it to check if we're on the ground.
- Add a Rigidbody to the Feet. This will allow it to detect trigger events with static colliders that don't have Rigidbodies on them, like the environment.
- The feet's local position and rotation should always stay the same and shouldn't _really_ be affected by the Rigidbody, since we always want it to stay at the "Feet" of the player. As such, you should freeze the position and rotation within the Rigidbody constraints.

### Scripting Requirements

#### Unchanged Requirements from Project 1A

Below are the requirements for the player controller of project 1A that still hold for this project:

- It should be first-person.
- When the up/down arrow keys or W/S keys are pressed down the character should move forwards/backwards.
- When the left/right arrow keys or A/D keys are pressed down the character should move left/right.
- The movements described in the last two points should be **relative to the camera, not in global world coordinates.**
- Movements along different axes may be combined. In other words, a user should be able to move diagonally by hitting one of the vertical and one of the horizontal keys at the same time.
- The character should keep moving in the appropriate direction(s) while the corresponding key(s) is held down. It should only stop moving in that direction once the key is no longer pressed, and it must do so as soon as the key is released (i.e. not couple of seconds afterwards).
- When the mouse is moved to the left or right the camera should rotate left or right, and when the mouse is moved up/down the camera should also rotate up/down. Similar to the positional movement, the rotational movement in different directions may be combined.
- Since the mouse translational movement is relative to the camera, if the camera rotates based on mouse input, then the direction of the translational movement should also change at the same time.
- You should be able to edit the speed of translation and the speed of rotation from the Editor.

#### Additional Requirements

Additionally, there are some new requirements introduced for your player controller script in this project.

- You **must** use methods of the Rigidbody class (and/or modify its properties) when affecting the positional or rotation movements of the _**Player**_ GameObject; you may not use Transform methods to do so. Note that this restriction only applies to movements made to the _**Player**_ GameObject itself; you may continue to use Transform methods for any movement applied to the _**Head**_ if necessary, since it does not contain a Rigidbody and is not affected by Physics.
- All methods of the Rigidbody or modifications to its properties must be applied during the FixedUpdate event, at least in the context of player movement.
- All user input must be gathered during the Update event. You cannot get input in FixedUpdate since it is not guaranteed to be fired every frame and this could potentially cause input to be lost in some edge cases.
- If a user presses the space bar they should jump, but only if their feet are touching the ground or some other object (in other words, you shouldn't be able to initiate a new jump if you're already in the air).
- If the player falls off the edge of the environment, their position should be reset to 5 meters above the starting location (i.e. point <0, 5, 0> if you did everything correctly in project 1A) and the rotation should be reset to `Quaternion.identity`. This would cause them to respawn and fall back onto their starting position. You are welcome to use Transform functions/properties in your implementation for this specific task if you would like.

#### Tips on Implementation

##### Jumping

Rather than trying to detect if you're on the ground from the Player Controller script (since you could be colliding with many other GameObjects even when you're not on the ground, such as sliding off a wall or tree when you're in mid-air), you could attach a script to the _**Feet**_ GameObject to accomplish this (since its box collider is less wide/deep than the capsule's and only present at its bottom point). You would then need to design a way to access this "grounded" information from the PlayerController script in order to implement jumping.

##### Respawning After Death

You should detect the trigger underneath the environment using the Player Controller script that's attached to the _**Player**_ GameObject. If you simply tried to implement this script on the _**Feet**_ GameObject, it would not work since two triggers cannot detect each other; at least one must be a non-trigger collider for a collision/trigger event to be fired.

## [Previous Section](../environmental-physics) | [Go Home](..) | [Next Section](../spawn-barrels)
