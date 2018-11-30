﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/RaycastWeapon")]
public class RaycastWeapon : WeaponScript {

	public int damage;
	public float range;
	public float force;

	public override void FireWeapon(PlayerWeaponHandler weaponHandler)
	{
		weaponHandler.RaycastFire(damage, range, force);
	}
}
