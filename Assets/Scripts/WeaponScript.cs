using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponScript : ScriptableObject {
    //once all weapons are in the game we will change this to only take in ammo types and mana
    public float baseCooldown;
	public List<AudioClip> WeaponSounds;

    protected float cooldown = 0;
	public abstract bool CanFire(PlayerWeaponHandler weaponHandler);
	public abstract void FireWeapon(PlayerWeaponHandler weaponHandler);



    public void UpdateCooldown(float time)
    {
        cooldown -= time;
    }

	public void PlayAudio(AudioSource source)
	{
		if(WeaponSounds.Count > 0)
		{
			AudioClip clip = null;
			if(WeaponSounds.Count == 1)
			{
				clip = WeaponSounds[0];
			}
			else
			{
				clip = WeaponSounds[Random.Range(0, WeaponSounds.Count)];
			}
			source.clip = clip;
			source.Play();
		}
	}
}
