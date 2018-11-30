using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerWeaponHandler : MonoBehaviour {

    //public Transform gunEnd;
    private Camera fpsCamera;

	public WeaponScript weapon;
	public WeaponScript spell;

	private void Awake()
    {
        fpsCamera = Camera.main;
    }

	public void RaycastFire(int damage, float range, float force)
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
				enemy.AddKnockBack(fpsCamera.transform.forward, force);
			}
        }
    }

	void Update()
	{
        if (Input.GetButtonDown("Fire1"))
		{
			weapon.FireWeapon(this);
		}
		if (Input.GetButtonDown("Fire2"))
		{
			spell.FireWeapon(this);
		}
	}
}
