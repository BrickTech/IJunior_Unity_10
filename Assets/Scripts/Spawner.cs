using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
    private Exploder _exploder;
    private int _partAmount;
    private int _minPartAmount = 2;
    private int _maxPartAmount = 6;

    private void Awake()
    {
        _exploder = GetComponent<Exploder>();
    }

    public void Spawn(Block block)
    {
        List<Rigidbody> blocks = new List<Rigidbody>();
        Transform transform = block.transform;

        _partAmount = Random.Range(_minPartAmount, _maxPartAmount);

        for (int i = 0; i < _partAmount + 1; i++)
        {
            Block copy = Instantiate(block, transform.position, Random.rotation);

            copy.SetChance(block.Chance);
            copy.ReduceScale();
            
            if (copy.TryGetComponent(out Rigidbody rigidbody))
                blocks.Add(rigidbody);

            _exploder.Explode(blocks, transform);
        }
    }
}
