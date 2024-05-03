using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    private int _leftMouseClick = 0;

    private void Update()
    {
        ShootRay();
    }

    private void ShootRay()
    {
        if (Input.GetMouseButtonDown(_leftMouseClick))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Transform _objectHit = hit.transform;

                if (_objectHit.TryGetComponent<Exploder>(out Exploder exploder))
                    exploder.Explode(exploder);
            }
        }
    }
}


