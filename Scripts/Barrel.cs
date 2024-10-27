using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionForce;
    [SerializeField] private ParticleSystem effect;

    private void OnMouseUpAsButton()
    {
        Explode();
        Instantiate(effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in getExplodableObjects())
            explodableObject.AddExplosionForce(explosionForce, transform.position, explosionRadius);
    }

    private List<Rigidbody> getExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        List<Rigidbody> barrels = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                barrels.Add(hit.attachedRigidbody);
            }
        }
        return barrels;
    }
}
