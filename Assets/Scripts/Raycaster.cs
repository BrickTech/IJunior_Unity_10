using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;

    private Transform _objectHit;
    private Exploder _exploder;

    private void Update()
    {
        GetObject();
    }

    private void GetObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
            {
                _objectHit = hit.transform;

                if (_objectHit.TryGetComponent<Block>(out Block block))
                {
                    _exploder = _objectHit.GetComponent<Exploder>();
                    _exploder.Explode(block);
                }
            }
        }
    }
}


