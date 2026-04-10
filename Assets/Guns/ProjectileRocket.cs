using UnityEngine;

public class ProjectileRocket : MonoBehaviour
{
    [SerializeField] GameObject prefabRocketExplosion;
    private void OnDestroy()
    {
        Instantiate(prefabRocketExplosion, transform.position, prefabRocketExplosion.transform.rotation);
    }
}
