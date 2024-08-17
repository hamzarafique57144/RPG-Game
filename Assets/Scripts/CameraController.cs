using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float pitch = 2f;
    [SerializeField] float currentZoom = 10f;
    [SerializeField] float zoomSpeed = 4f;
    [SerializeField] float minZoom = 5f;
    [SerializeField] float maxZoom = 15f;
    [SerializeField] float yawSpeed = 100f;
    private float currentYaw = 0f;
    private void Update()
    {
        currentZoom -= Input.GetAxis("Vertical") * zoomSpeed*Time.deltaTime;
        currentZoom = Mathf.Clamp(currentZoom,minZoom,maxZoom);
        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }
    private void LateUpdate()
    {
        transform.position = target.position - offset*currentZoom;
        transform.LookAt(target.position+ Vector3.up*pitch);
        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
