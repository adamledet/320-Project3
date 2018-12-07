using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spell/FireBallSpell")]
public class FireballSpell : WeaponScript {

	public float manaCost;
    public GameObject ballObj;

	public override bool CanFire(PlayerWeaponHandler weaponHandler)
	{
		return weaponHandler.Mana >= manaCost;
	}

	public override void FireWeapon(PlayerWeaponHandler weaponHandler)
	{
        GameObject fireball = Instantiate(ballObj, weaponHandler.transform.position, Quaternion.identity);
		weaponHandler.Mana -= manaCost;
	}
}
