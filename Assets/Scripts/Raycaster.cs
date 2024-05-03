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

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                if (hit.transform.TryGetComponent<Block>(out Block block))
                    block.OnClick();
            }
        }
    }
}


