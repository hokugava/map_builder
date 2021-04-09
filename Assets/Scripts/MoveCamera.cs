using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 _dragOrigin;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = _camera.ScreenToViewportPoint(Input.mousePosition - _dragOrigin);
        Vector3 move = new Vector3(pos.x * -dragSpeed * Time.deltaTime, pos.y * -dragSpeed * Time.deltaTime, 0);
        transform.Translate(move, Space.World);
    }
}