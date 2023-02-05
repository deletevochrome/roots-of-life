using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private Vector3 drag;
    [SerializeField]
    private float zoomSpeed = 10f;
    public float zoomSmoothSpeed = 0.125f;
    public float minZoom = 5f;
    public float maxZoom = 20f;

    private float targetZoom;

    void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        PanCamera();
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        targetZoom = Mathf.Clamp(Camera.main.orthographicSize - scroll * zoomSpeed, minZoom, maxZoom);
    }

    private void LateUpdate()
    {
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetZoom, zoomSmoothSpeed);
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(1))
        {
            drag = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(1))
        {
            Vector3 difference = drag - cam.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log("Origin" + drag + " newPosition" + cam.ScreenToWorldPoint(Input.mousePosition) + " =difference" + difference);

            cam.transform.position += difference;
        }
    }
}