using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class CameraFocusController: MonoBehaviour {

 void Start() {
  var vuforia = VuforiaARController.Instance;
  vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
  vuforia.RegisterOnPauseCallback(OnPaused);
 }

 // FOCUS_MODE_CONTINUOUSAUTO guarantees that the camera is focused on the target
 private void OnVuforiaStarted() {
  CameraDevice.Instance.SetFocusMode(
      CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
 }

 private void OnPaused(bool paused) {
  if (!paused) // resumed
  {
       // Set again autofocus mode when app is resumed
       CameraDevice.Instance.SetFocusMode(
          CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
  }
 }
}



