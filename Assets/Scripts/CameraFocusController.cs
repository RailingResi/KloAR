﻿/* 
    ------------------- CameraFocusController.cs -------------------

    Isabella Horn, 25.July 2020:
     On my Xiaomi Android device I had the problem
     that the camera did not focus automatically 
     and therefore the target was not recognized. 
     This script guarantees that the focus is on the target 
     and when the app is resumed then set autofocus again

    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
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



