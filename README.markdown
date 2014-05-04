# t2d-trackingcamera

A tracking camera behavior for the [Torque 2D][] game engine.
Basic usage:

    TrackingCamera.addToWindow(TheSceneWindow);
    TrackingCamera.track(%player);
    TrackingCamera.track(%buddy);

# Installation

I recommend cloning this repository right into your T2D folder:

```
git clone git@github.com:eightyeight/t2d-trackingcamera modules/TrackingCamera
```

Or you can achieve the same effect by [downloading a ZIP file][Download].
Note that this will download the latest version of the `master` branch, which will be stable
but may be out of date.

[Torque 2D]: https://github.com/GarageGames/Torque2D
[Download]: https://github.com/eightyeight/t2d-trackingcamera/archive/master.zip
