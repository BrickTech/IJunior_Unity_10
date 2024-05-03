using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 20f;
    [SerializeField] private float _explosionForce = 700f;

    private int _reproduceChance = 100;
    private int _decreaceChance = 2;
    private int _partAmount;
    private static int _minPartAmount = 2;
    private static int _maxPartAmount = 6;

    public void Explode(Exploder exploder)
    {
            if (isChanceEnough())
            {
                List<Rigidbody> blocks = new();
                _partAmount = Random.Range(_minPartAmount, _maxPartAmount);

                for (int i = 0; i < _partAmount + 1; i++)
                {
                    Exploder copy = Instantiate(exploder, transform.position, Random.rotation);

                    if (copy.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
                    {
                        blocks.Add(rigidbody);
                    }
                    else
                    {
                        return;
                    }

                    int newReproduceChance = DecreaceChance(_reproduceChance);

                    exploder.SetChance(newReproduceChance);
                }

                foreach (Rigidbody item in blocks)
                    item.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
            
            Destroy(exploder.gameObject);
    }

    public void SetChance(int newChance)
    {
        _reproduceChance = newChance;
    }

    private int DecreaceChance(int reproduceChance)
    {
        return reproduceChance / _decreaceChance;
    }

    private bool isChanceEnough()
    {
        int minChance = 0;
        int maxChance = 100;
        int randomChance = Random.Range(minChance, maxChance + 1);

        return _reproduceChance >= randomChance;
    }
}