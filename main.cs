function TrackingCamera::create(%this) {
}

function TrackingCamera::destroy(%this) {
   if(isObject(%this.Instance)) {
      %this.Instance.trackObjects.delete();
      %this.Instance.delete();
      %this.Instance = "";
   }
}

function TrackingCamera::addToWindow(%this, %window) {
   if(isObject(%this.Instance)) {
      %window.mount(%this.Instance);
   } else {
      %c = new SceneObject() { class="TrackingCameraInstance"; };
      %c.setVisible(false);
      %c.setGravityScale(0);
      %c.setUpdateCallback(true);
      %c.trackObjects = new SimSet();
      %c.window = %window;
      %c.minSize = %window.getCameraSize();
      %this.Instance = %c;
      %window.getScene().add(%c);
      %window.mount(%c);
   }
}

function TrackingCamera::track(%this, %obj) {
   if(isObject(%this.Instance)) {
      %this.Instance.trackObjects.add(%obj);
   }
}

function TrackingCameraInstance::onUpdate(%this) {
   if(!%this.trackObjects.getCount()) {
      return;
   }
   %avg = "0 0";
   %max = "0 0";
   %i = 0;
   while(%i < %this.trackObjects.getCount()) {
      %pos = VectorAdd(%pos, %this.trackObjects.getObject(%i).getPosition());
      %diff = VectorSub(%pos, %this.getPosition());
      if(VectorLen(%diff) > VectorLen(%max)) {
         %max = %diff;
      }
      %i++;
   }
   %pos = VectorScale(%pos, 1 / %this.trackObjects.getCount());
   %this.moveTo(%pos.x, %pos.y, 3);
   %scaleX = mAbs(%max.x) / %this.minSize.x;
   %scaleY = mAbs(%max.y) / %this.minSize.y;
   %scale = mGetMax(%scaleX, %scaleY);
   if(%scale > 0.4) {
      %size = VectorScale(%this.minSize, %scale * 10/4);
      %this.window.setCameraSize(%size);
   } else {
      %this.window.setCameraSize(%this.minSize);
   }
}
