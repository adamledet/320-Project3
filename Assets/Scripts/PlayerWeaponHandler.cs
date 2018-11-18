using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerWeaponHandler : MonoBehaviour {

   //public Transform gunEnd;

    private Camera fpsCamera;

    private void Awake()
    {
        fpsCamera = Camera.main;
    }

    public void RaycastFire(int damage, float range)
    {
        Vector3 castOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        RaycastHit target;
        if(Physics.Raycast(castOrigin, fpsCamera.transform.forward, out target, range))
        {
			//code to damage goes here
			EnemyController enemy = target.collider.GetComponent<EnemyController>();
			if(enemy != null)
			{
				enemy.Damage(damage);
			}
        }
    }

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			RaycastFire(1, 1000);
		}
	}
}
