# ScrollList
Here is an optimization example for ScrollList in Unity. Although it is a simple demonstration, it can be used as a reference for creating large lists and modified to fit your own needs.

![ScrollRect](https://user-images.githubusercontent.com/50480696/236126314-9b0d136b-1b00-4b89-b2a8-9c1365e10828.gif)
We use the built-in Profiler tool in Unity to observe CPU usage.

![ScrollRect1](https://user-images.githubusercontent.com/50480696/236135351-779afeb8-c02f-4ca8-b140-2fa0ff518d7c.gif)
Above is a comparison of the difference between Tris and Verts.

![ScrollRect2](https://user-images.githubusercontent.com/50480696/236135376-93e753da-cc90-4385-96cf-0670d24dacdc.gif)
After turning off the masks for both, it can be observed that one scroll list uses 1,000 objects while the other scroll list only uses 6 objects.
