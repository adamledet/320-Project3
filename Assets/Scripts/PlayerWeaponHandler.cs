using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerWeaponHandler : MonoBehaviour {

    //public Transform gunEnd;
    private Camera fpsCamera;

	public WeaponScript weapon;
	public WeaponScript spell;

    //Mana Attributes
    public float maxMana;
    float mana;
    public float spellCost;
    public float manaRegenRate;
    public Slider manaMeter;

	private void Awake()
    {
        fpsCamera = Camera.main;
    }

    private void Start()
    {
        mana = maxMana;
        manaMeter.maxValue = maxMana;
        manaMeter.value = mana;
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
        //Mana Regeneration
        if (mana < maxMana)
            mana += manaRegenRate;
        else
            mana = maxMana;

        manaMeter.value = mana;


        if (Input.GetButtonDown("Fire1"))//Pistol Fire
		{
			weapon.FireWeapon(this);
		}
		if (Input.GetButtonDown("Fire2"))//Force Push
		{
            //Cast spell if enought mana. 
            if(mana >= spellCost)
            {
                spell.FireWeapon(this);
                mana -= spellCost;
            }
		}
	}
}
