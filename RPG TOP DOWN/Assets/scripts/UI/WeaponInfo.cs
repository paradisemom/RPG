using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="New Weapon")]
public class WeaponInfo : ScriptableObject
{
   public GameObject weaponPrefab;
   public float weaponCoolDdwn;
   public int weaponDamage;
   public float weaponRange;
}
