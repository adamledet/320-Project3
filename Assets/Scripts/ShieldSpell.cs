using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spell/ShieldSpell")]
public class ShieldSpell : WeaponScript
{
	public float manaCost;
	public float radius;

	public override bool CanFire(PlayerWeaponHandler weaponHandler)
	{
		return weaponHandler.Mana >= manaCost;
	}

	public override void FireWeapon(PlayerWeaponHandler weaponHandler)
	{
		Vector3 playerPosition = weaponHandler.transform.position;
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject target in enemies)
		{
			float distance = Vector3.Distance(target.transform.position, playerPosition);
			if(distance < radius)
			{
				target.GetComponent<EnemyController>().AddKnockBack(target.transform.position - playerPosition, radius - distance);
			}
		}
		weaponHandler.Mana -= manaCost;
	}
}
