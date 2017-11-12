using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJCamFree : MonoBehaviour {

    //
    // VARIABLES
    //

    public float turnSpeed = 4.0f;      // Speed of camera turning when mouse moves in along an axis
    public float panSpeed = 4.0f;       // Speed of the camera when being panned
    public float zoomSpeed = 4.0f;      // Speed of the camera going back and forth

    private Vector3 mouseOrigin;    // Position of cursor when mouse dragging starts
    private bool isPanning;     // Is the camera being panned?
    private bool isRotating;    // Is the camera being rotated?

    private Camera cam;
    //
    // START
    //
    void Start()
    {
        cam = GetComponent<Camera>();
    }
    //
    // UPDATE
    //

    void Update()
    {
        // Get the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }

        // Get the right mouse button
        if (Input.GetMouseButtonDown(1))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isPanning = true;
        }

        // Disable movements on button release
        if (!Input.GetMouseButton(0)) isRotating = false;
        if (!Input.GetMouseButton(1)) isPanning = false;

        // Rotate camera along X and Y axis
        if (isRotating)
        {
            Vector3 pos = cam.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
            transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
        }

        // Move the camera on it's XY plane
        if (isPanning)
        {
            Vector3 pos = cam.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
            transform.Translate(move, Space.Self);
        }

        // Move the camera linearly along Z axis
        if (Input.GetAxis("Mouse ScrollWheel") >0)
        {
            Vector3 pos = cam.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = pos.y * zoomSpeed * transform.forward;
            transform.Translate(move, Space.World);
        }

        // Move the camera linearly along Z axis
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Vector3 pos = cam.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = pos.y * zoomSpeed * (-transform.forward);
            transform.Translate(move, Space.World);
        }
    }
}
