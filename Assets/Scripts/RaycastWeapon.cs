using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/RaycastWeapon")]
public class RaycastWeapon : WeaponScript {

	public int damage;
	public float range;
	public float force;

	public override bool CanFire(PlayerWeaponHandler weaponHandler)
	{
        return (cooldown <= 0&&weaponHandler.Ammo > 0);
	}
	public override void FireWeapon(PlayerWeaponHandler weaponHandler)
	{
		weaponHandler.RaycastFire(damage, range, force);
		weaponHandler.Ammo -= 1;
		cooldown = baseCooldown;
	}
}
