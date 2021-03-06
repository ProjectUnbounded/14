﻿using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

	void Awake() {
		transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
		Color whateverColor = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f),1f);
		MeshRenderer gameObjectRenderer = GetComponent<MeshRenderer>();
		Material newMaterial = new Material(Shader.Find("Standard"));
		float ranScale = Random.Range (0.4f, 0.6f);
		newMaterial.color = whateverColor;
		gameObjectRenderer.material = newMaterial ;
		Destroy (gameObject, 3.5f);
	}


}
