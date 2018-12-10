﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerWeaponHandler : MonoBehaviour {

	//public Transform gunEnd;
	private Camera fpsCamera;

	public WeaponScript weapon;
	public WeaponScript shieldSpell;
    public WeaponScript firebalSpell;

	//Mana Attributes
	public float maxMana;
	public float manaRegenRate;
	public Slider manaMeter;
	public float Mana
	{
		get
		{
			return mana;
		}
		set
		{
			mana = value;
			if(mana < 0)
			{
				mana = 0;
			}
		}
	}
	private float mana;
	public Text ammoText;
	public int maxAmmo;
	public int Ammo
	{
		get
		{
			return ammo;
		}
		set
		{
			ammo = value;
			if (ammo > maxAmmo)
			{
				ammo = maxAmmo;
			}
			UpdateAmmoText();
		}
	}
	private int ammo;
	public float reloadRate;
	private float reloadTime;
    public Slider bulletSliderL;
    public Slider bulletSliderR;

	private void Awake()
	{
		fpsCamera = Camera.main;
	}

	private void Start()
	{
        bulletSliderL.maxValue = maxAmmo;
        bulletSliderR.maxValue = maxAmmo;
        mana = maxMana;
		manaMeter.maxValue = maxMana;
		ammo = maxAmmo;
		UpdateAmmoText();
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
        if(!GetComponent<PlayerCollisions>().IsPaused && !GetComponent<PlayerCollisions>().gameOverScreen.activeSelf)
        {
            //Mana Regeneration
            if (mana < maxMana)
            {
                mana += manaRegenRate;
            }
            else
            {
                mana = maxMana;
            }

            manaMeter.value = mana;
			if (reloadTime > 0)
			{
				reloadTime -= Time.deltaTime;
				if(reloadTime <= 0)
				{
					Ammo = maxAmmo;
				}
			}
			else
			{
				if (Input.GetButtonDown("Fire1") && weapon.CanFire(this))//Pistol Fire
				{
					weapon.FireWeapon(this);
				}
				if (Input.GetButtonDown("Fire2") && shieldSpell.CanFire(this))//Force Push
				{
                    shieldSpell.FireWeapon(this);
				}
				if (Input.GetButtonDown("Reload"))//Reload
				{
					reloadTime = reloadRate;
				}
                if(Input.GetButtonDown("Fireball") && firebalSpell.CanFire(this))//Fireball
                {
                    firebalSpell.FireWeapon(this);
                }
			}

            weapon.UpdateCooldown(Time.deltaTime);
        }
	}
	private void UpdateAmmoText()
	{
		ammoText.text = ammo + "/"+maxAmmo;
        if(ammo == 6)
        {
            bulletSliderL.value = bulletSliderL.maxValue;
            bulletSliderR.value = bulletSliderR.maxValue;
        }
        else if (ammo == 5)
        {
            bulletSliderL.value = bulletSliderL.maxValue;
            bulletSliderR.value = 3.75f;
        }
        else if (ammo == 4)
        {
            bulletSliderL.value = bulletSliderL.maxValue;
            bulletSliderR.value = 1.75f;
        }
        else if (ammo == 3)
        {
            bulletSliderL.value = bulletSliderL.maxValue;
            bulletSliderR.value = 0;
        }
        else if (ammo == 2)
        {
            bulletSliderL.value = 3.75f;
            bulletSliderR.value = 0;
        }
        else if (ammo == 1)
        {
            bulletSliderL.value = 1.75f;
            bulletSliderR.value = 0;
        }
        else if (ammo == 0)
        {
            bulletSliderL.value = 0;
            bulletSliderR.value = 0;
        }
    }
}
