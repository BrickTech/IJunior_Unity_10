using UnityEngine;

public class Block : MonoBehaviour 
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private float _scaleDecrease;

    private Renderer _renderer;
    private ColorChanger _colorChanger;
    private float _scaleReducer = 2;
    
    private void Awake()
    {
        _colorChanger = new ColorChanger();

        if(TryGetComponent(out Renderer renderer))
        {
            _renderer = renderer;

            _colorChanger.ChangeColor(_renderer.material);
            ReduceScale(_scaleReducer);
        }
    }

    public void ReduceScale(float decrease)
    {
        transform.localScale /= decrease;
    }
}
