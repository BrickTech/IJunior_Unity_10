using UnityEngine;

public class Block : MonoBehaviour 
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private float _scaleDecrease;

    private Renderer _renderer;
    private ColorChanger _colorChanger;
    
    private void Awake()
    {
        _colorChanger = new ColorChanger();
        _renderer = GetComponent<Renderer>();

        _colorChanger.ChangeColor(_renderer.material);
        ScaleDecrease(2f);
    }

    public void ScaleDecrease(float decrease)
    {
        transform.localScale /= decrease;
    }
}
