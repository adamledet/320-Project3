using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponScript : ScriptableObject {

	public abstract void FireWeapon(PlayerWeaponHandler weaponHandler);
}
