# Project 1C: Barrel Bouncer (UI & Scoring)

## Part 5: Pausing

By this point we assume that you can create your own UIs. The example screenshot has been provided below. All GameObjects for this UI should be descendants of the Pause Menu Screen. Each of the buttons should work correctly and their functionality is self-explanatory.

![A sample pause menu for Barrel Bouncer](images/pause-menu.png)

When the game is paused, the pause menu screen should show and when the game is unpaused, the regular screen should show.

The user can pause the game by hitting the escape key and unpause it by hitting the escape key again. To make it easier, you are allowed to poll for input of the escape key on the Screen Switcher script.

Additionally, when the game pauses, the player should not be able to move and all moving objects (such as balls or falling barrels) should freeze in place. The easiest way to do this is by modifying the static [Time.timeScale](https://docs.unity3d.com/ScriptReference/Time-timeScale.html) value to stop time. Remember to reset it to realtime once the game is unpaused.

### Bonus Task (Optional)

- Implement a 3..2..1.. countdown before switching back to an unpaused state in order to give the user some time to orient themselves to the environment.

## [Previous Section](../scoring) | [Go Home](..) | [Next Section](../game-over)
