using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 20f;
    [SerializeField] private float _explosionForce = 700f;

    public void Explode(List<Rigidbody> blocks, Transform transform)
    {
        if (blocks.Count > 0)
            foreach (Rigidbody block in blocks)
                block.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}