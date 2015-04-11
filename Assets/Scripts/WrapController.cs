﻿using UnityEngine;
using System.Collections;

public class WrapController : MonoBehaviour {


	void OnBecameInvisible() 
	{
		Debug.Log (" Out of screen!" );
		var cam = Camera.main;
		var viewportPosition = cam.WorldToViewportPoint (transform.position);
		var newPosition = transform.position;
		
		if (viewportPosition.x > 1 || viewportPosition.x < 0)
		{
			print("TODO: draw!!!!! X ");
			newPosition.y = -newPosition.y;
		}
		
		if (viewportPosition.y > 1 || viewportPosition.y < 0)
		{
			print("TODO: Draw!!!!! Y ");
			newPosition.y = -newPosition.y;
		}
		
		transform.position = newPosition;
		
	}
}
