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

    public bool InsufficientMana(PlayerWeaponHandler weaponHandler)
    {
        return weaponHandler.Mana <= manaCost;
    }

    public override void FireWeapon(PlayerWeaponHandler weaponHandler)
	{
        Instantiate(ballObj, (weaponHandler.transform.position + weaponHandler.transform.forward), weaponHandler.transform.rotation);
		weaponHandler.Mana -= manaCost;
	}
}
