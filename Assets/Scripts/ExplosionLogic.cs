using UnityEngine;
using UnityEngine.Events;

public class ExplosionLogic : MonoBehaviour
{
    UnityAction<HitData> OnHit;
    private void OnTriggerEnter(Collider other)
    {
        var target = other.gameObject.GetComponent<Damageable>();
        if (target != null)
        {
            var direction = GetComponent<Rigidbody>().linearVelocity;
            direction.Normalize();

            Debug.Log("hit enemy trigger");
            target.Hit(direction * 100, 100);

            HitData hd = new HitData();
            hd.target = target;
            hd.direction = direction;
            hd.location = transform.position;

            OnHit?.Invoke(hd);
        }
    }
}
