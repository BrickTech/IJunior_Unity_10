using UnityEngine;

public class Block : MonoBehaviour 
{
    [SerializeField] private int _scaleReduceValue = 2;
    [SerializeField] private Spawner _spawner;

    private Material _material;
    private int _decreaceChance = 2;
    private int _reproduceChance = 100;

    public int Chance => _reproduceChance;
    

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;

        ChangeColor(_material);
    }

    public void OnClick()
    {
        if (isChanceEnough())
        {
            _spawner.Spawn(this);
        }

        Destroy(transform.gameObject);
    }

    public void SetChance(int chance) =>
        _reproduceChance = chance / _decreaceChance;

    public void ReduceScale() =>
        transform.localScale /= _scaleReduceValue;

    private bool isChanceEnough()
    {
        int minChance = 0;
        int maxChance = 100;
        int randomChance = Random.Range(minChance, maxChance + 1);

        return _reproduceChance >= randomChance;
    }

    private void ChangeColor(Material material) =>
        material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
}
