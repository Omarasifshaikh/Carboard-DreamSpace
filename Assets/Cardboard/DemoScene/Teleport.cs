﻿// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour {
  private Vector3 startingPosition;
	public Canvas canvas;
	public Slider slider;
	public Text degree;
  void Start() {
    startingPosition = transform.localPosition;
    SetGazedAt(false);
		//canvas = GetComponentInChildren<Canvas> ();
		canvas.enabled = false;
  }

  public void SetGazedAt(bool gazedAt) {
    GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.white;
  }

  public void Reset() {
    transform.localPosition = startingPosition;
  }

  public void ToggleVRMode() {
    Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
  }

  public void TeleportRandomly() {
		canvas.enabled = !canvas.enabled;
	/*
    Vector3 direction = Random.onUnitSphere;
    direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
    float distance = 2 * Random.value + 1.5f;
    transform.localPosition = direction * distance;
    */
  }
	public void tempUP()
	{
		slider.value = Mathf.Min (1f, slider.value + 0.1f);

	}
	public void tempDown()
	{
		slider.value = Mathf.Max (0f, slider.value - 0.1f);
	}

	void Update(){
		degree.text = string.Format ("{0}", (int)((100 - 32) * slider.value + 32));
	}
}
