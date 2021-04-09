using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float zoomSpeed;
    public float orthographicSizeMin;
    public float orthographicSizeMax;
    public float fovMin;
    public float fovMax;
    private Camera _camera;
    void Start () {
        _camera = GetComponent<Camera>();
    }
  
    void Update () {
        if (_camera.orthographic)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                _camera.orthographicSize += zoomSpeed*Time.deltaTime;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                _camera.orthographicSize -= zoomSpeed*Time.deltaTime;
            }
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, orthographicSizeMin, orthographicSizeMax);
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                _camera.fieldOfView += zoomSpeed*Time.deltaTime;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                _camera.fieldOfView -= zoomSpeed*Time.deltaTime;
            }
            _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, fovMin, fovMax);
        }
    }
}
