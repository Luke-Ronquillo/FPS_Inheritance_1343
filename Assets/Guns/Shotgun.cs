using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] GameObject prefabShotgunBlast;
    public override bool AttemptFire()
    {
        if (!base.AttemptFire())
            return false;

        var b = Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        b.GetComponent<Projectile>().Initialize(10, 300, 0.3f, 25, null); // version without special effect

        Instantiate(prefabShotgunBlast, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);

        anim.SetTrigger("shoot");
        elapsed = 0;
        ammo -= 1;

        return true;
    }
}
