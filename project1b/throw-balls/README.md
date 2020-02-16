# Project 1B: Barrel Bouncer (Interactions)

## Part 4: Throwing Bouncy Balls

In this section, you will be implementing functionality where you throw a bouncy ball when you left-click on your mouse in order to try to destroy barrels.

### Creating the Ball Prefab

To complete the setup for this section, follow these steps:

- Create a new sphere by going to `GameObject` -> `3D Object` -> `Sphere`.
- Make your own material with a cool color or image texture and apply it onto your sphere.
- Add a Rigidbody to the sphere in order to make it a physical object that is affected by physics and gravity.
- Apply a physic material to make the ball bounce appropriately.
- Scale your ball so that it is appropriately the size of a tennis ball.
- Make this ball into a prefab and remove any instances of the barrel from your scene.

### Writing the Scripts

In your player controller, you should define a public reference to the ball prefab and implement the following functionality:

- When the left button of your mouse is clicked, the player should throw a new ball in the direction they are facing.
- The ball should be launched using Rigidbody functions and should move in a projectile fashion.

You should also implement the following functionality, but it does not necessarily have to be in the player controller script:

- If a ball collides with a barrel object the barrel should be destroyed.
- Regardless of if anything is hit, the ball should destroy itself after 5 seconds.

### Bonus Tasks (Optional)

- Instead of destroying the barrel immediately upon impact with a ball, add a particle effect to it for 3 seconds before destroying it. Check out [this package](https://assetstore.unity.com/packages/essentials/tutorial-projects/unity-particle-pack-127325) for some cool effects.
- Add some enemy non-player characters (NPC), like zombies, pirates, or dragons, into your scene that constantly move towards the player. They should obey the laws of physics and should also be destroyed if a ball hits it. Additionally, you should use Unity's [navigation system](https://docs.unity3d.com/Manual/Navigation.html) to set the NavMesh and obstacles so that the NPC agents can use pathfinding algorithms and AI to appropriately move around.

## [Previous Section](../spawn-barrels) | [Go Home](..) | [Next Section](../3d-sound)
