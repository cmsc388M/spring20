# Project 3: Barrel Bouncer AR Edition

## Part 8: Going into Gameplay Mode

Once the user enters Gameplay Mode, their main objective is to throw balls around to destroy the barrels and score points. In this project, you will be accomplishing this in a similar way to what you did in project 1. When a user taps the screen, a new ball should be created and thrown from the center of the phone's camera in the direction that the phone is facing. The Unity Documentation contains some great examples on how to use touch input [here](https://docs.unity3d.com/ScriptReference/Input.GetTouch.html).

Note that all of the ball-related functionality from project 1 should still be working correctly in this project, such as destroying the ball 5 seconds after being thrown, destroying barrels upon impact, having a bouncy behavior, correctly utilizing all 3 spatial audio effects, and showing "+1" world-space text when a barrel is destroyed. Additionally, similar to project 2, you should make sure your balls are of a realistic size in the real world (i.e. approximately the size of a tennis ball). However, you do not need to worry about including any of the other adjustments you made to project 2, such as enhancing the spatial audio effects beyond what you were able to do in project 1.

Finally, when the timer runs out or when there are no more barrels left to destroy (whichever comes first), you should advance to the _**GameOver**_ scene, which is described in the next section.

## [Previous Section](../phone-uis) | [Go Home](..) | [Next Section](../game-loop)
