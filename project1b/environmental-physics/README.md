# Project 1B: Barrel Bouncer (Interactions)

## Part 1: Making Your Environment Visible to the Physics System

In project 1A, you designed a new environment from scratch. However, as we saw last class, what you see in your scene is not necessarily the same as what the physics system sees. In this section, you will be shaping the physics system's understanding of your environment by adding colliders to the GameObjects in your scene. Below are some important considerations you should think about as you work with your environment.

### Do Your GameObjects Already Have Colliders?

It's possible that some of the GameObjects in your environment already have colliders attached to them, particularly if they came from the Asset Store or if you used the Terrain Tools. It is fairly easy to tell if a GameObject has a collider on it; if you select it in the Hierarchy (or Scene View), you will see a green wireframe outlining the geometry seen by the physics system when you observe the GameObject in the Scene View. Additionally, since a parent GameObject shows the renderings of all its child GameObjects, if you select the _**Environment**_ GameObject, it will highlight all of the colliders of its child GameObjects within the Scene View.

### Does a GameObject Even Need a Collider?

It is important to think about whether or not a GameObject actually needs a collider in the first place. Obviously, objects like the ground, a wall, stairs, or a building should have colliders on them, since you shouldn't be able to walk through them and a ball should be able to bounce off of them. On the other hand, it would be pretty silly and unrealistic if a ball could bounce off of a flower the same way it would off of a lamp pole or if you could stand on top of water or a strand of grass the same way you would on top of a rock. Such GameObjects should not have a collider on them.

### How Detailed Should a Collider Be?

The next thing you'll want to consider is the complexity of each collider. As we discussed in class, there is always a tradeoff between performance and the amount of detail you are defining for the collider. You should aim to have your colliders be good enough, opting for primitve colliders (i.e. box, sphere, capsule) and compound colliders made up of those where possible as opposed to using mesh colliders for everything. For example, a backyard fence could just be represented with a box collider, since you don't really care about the pointy spokes on top or the spacings between each picket. A single box collider on something like an airplane wouldn't work, but you could still make a good approximation of its shape by compounding multiple primitive colliders to its different parts (e.g. capsule collider for its body, box colliders for its wings, tails, and landing gear). A mountain or rocky terrain might be best served with a mesh collider, especially if you really want to achieve a bumpy effect when walking on top of it. Overall, you should just use your best judgement to determine what type of collider setups to use for each GameObject in your environment.

### What About Those Rigidbodies?

None of the GameObjects in your environment should have a Rigidbody component, since they are all static and thus stay in place and don't move.

### The Trigger of Death

We want to have a way to detect if the player has fallen off the edge of the environment, in other words if they have "died" in the game. This way we could allow them to respawn back into the center of the environment, rather than free-fall forever. The first part of this implementation requires some setup on the Environment side.

- Create an empty GameObject named "Death Trigger" and make it a child GameObject of the environment. Reset its transform position if necessary.
- Add a box collider to it that has a tiny height but whose width and depth are much larger than the entire environment.
- Move the GameObject so that the top of the box collider is slightly below the lowest point of the environment (in other words, so that a player couldn't accidentally come onto it while they're legitimately inside the environment).
- Mark the collider as a trigger. This is because we don't want it to be a solid object that the player would stop on top of or be able to walk around on, but rather just an invisible platform that detects if something passes through it.

## [Previous Section](../notes) | [Go Home](..) | [Next Section](../player-controller)
