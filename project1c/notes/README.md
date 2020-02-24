# Project 1C: Barrel Bouncer (UI & Scoring)

## Part 0: Important Notes

### UI

When dealing with UIs, there are a few things you should take into consideration. Since they are common to all the UIs in this project, they will be posted once here as opposed to being repeated each time we discuss a new part of the UI to create.

#### TextMeshPro

You should always use TextMesh Pro versions of UI components rather than the default text. Whenever we refer to "text" in the rest of this project, we are in fact referring to the TextMesh Pro versions. In order to use TextMesh Pro, you must first import it into your project. To do so, go to the menu bar and navigate to `Window` -> `TextMeshPro` -> `Import TMP Essential Resources`.

To learn about the benefits of using TextMesh Pro, check out [this blog post](https://blogs.unity3d.com/2018/10/16/making-the-most-of-textmesh-pro-in-unity-2018/).

#### Sizing and Style

Any UI you make should be of an appropriate size (i.e. not too small or too large) and style (e.g. text contrast with background) in order to make it usable, readable, and visually appealing. If anything you create is not of an appropriate size or style, you could lose points for the UI setup.

#### Scaling

You should use the _**Canvas Scaler**_ component we discussed in class in order to make sure your UIs work on different screen sizes and resolutions. This is especially important since your computer screen and our computer screens may be of different sizes, which could cause the UI to show up differently on our computers while grading if you don't set this up properly.

### Events

As we discussed from the examples in class, there are two ways of handling events. The first is with general C# events and delegates. The second is with Unity Events. You are welcome to use either in your implementation, but if you use the first method, then you need to make sure that you subscribe to the events during the OnEnable function and unsubscribe to it in the OnDisable function, in order to make that the event is not null-pointing to a method on a currently disabled (or destroyed) GameObject or script.

### Bonus Task (Optional)

- All of the UI you are implementing in this section will just make use of the default styles of each component (i.e. maybe just changing a color at most). As a bonus task, you could add some additional visual flair and polish to your UI rather than just keeping the default look. For example, you could add fun fonts and give the buttons a wooden, barrel-y look to fit the overall theme. This task is stated here because it applies to all of the parts.

## [Go Home](..) | [Next Section](../main-menu)
