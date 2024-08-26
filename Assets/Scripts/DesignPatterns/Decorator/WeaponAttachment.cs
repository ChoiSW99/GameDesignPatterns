using UnityEngine;

[CreateAssetMenu(fileName ="NewWeaponAttachment", menuName ="Weapon/Attachment", order = 1)]
public class WeaponAttachment : ScriptableObject, IWeapon
{
    [Range(0, 50)]
    [Tooltip("Increase rate of firing per second")]
    [SerializeField]
    private float rate;
    public float Rate { get { return rate; } }

    [Range(0, 50)]
    [Tooltip("Increase weapon range")]
    [SerializeField]
    private float range;
    public float Range { get { return range; } }

    [Range(0, 50)]
    [Tooltip("Increase weapon strengh")]
    [SerializeField]
    private float strength;
    public float Strength { get { return strength; } }

    [Range(0, 50)]
    [Tooltip("Reduce weapon cooldown")]
    [SerializeField]
    private float cooldown;
    public float Cooldown { get { return cooldown; } }

    public string attachmentName;
    public GameObject attachmentPrefab;
    public string attachmentDescription;
}
