using UnityEngine;

[CreateAssetMenu(fileName = "NewWeaponConfig", menuName = "Weapon/Config", order = 1)]

public class WeaponConfig : ScriptableObject, IWeapon
{
    [Range(0, 50)]
    [Tooltip("Rate of firing per second")]
    [SerializeField]
    private float rate;
    public float Rate { get { return rate; } }

    [Range(0, 50)]
    [Tooltip("Weapon range")]
    [SerializeField]
    private float range;
    public float Range { get { return range; } }

    [Range(0, 50)]
    [Tooltip("Weapon strength")]
    [SerializeField]
    private float strength;
    public float Strength { get { return strength; } }

    [Range(0, 50)]
    [Tooltip("Cooldown duration")]
    [SerializeField]
    private float cooldown;
    public float Cooldown { get { return cooldown; } }

    public string weaponName;
    public GameObject weaponPrefab;
    public string weaponDescription;
}
