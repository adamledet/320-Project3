using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {
	public Vector3 size;
	public Vector3 GetRandomPointInArea()
	{
		float xOffset = Random.Range(0, size.x);
		float yOffset = Random.Range(0, size.y);
		float zOffset = Random.Range(0, size.z);
		return new Vector3(xOffset+transform.position.x,yOffset + transform.position.y, zOffset + transform.position.z);
	}
}
