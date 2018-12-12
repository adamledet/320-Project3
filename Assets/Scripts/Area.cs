using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {
	public Vector3 size;
	public Vector3 GetRandomPointInArea()
	{
		float xOffset = Random.Range(-size.x/2, size.x/2);
		float yOffset = Random.Range(-size.y/2, size.y/2);
		float zOffset = Random.Range(-size.z/2, size.z/2);
		return new Vector3(xOffset+transform.position.x,yOffset + transform.position.y, zOffset + transform.position.z);
	}
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position, size);
	}
}
