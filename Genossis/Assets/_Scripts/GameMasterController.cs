using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class GameMasterController : NetworkBehaviour
{
    private Camera camera;
    private Vector3 originalCameraPosition;
    private MouseLook mouseLook;
    private CurveControlledBob headBob = new CurveControlledBob();
    private float stepInterval = 4f;
    private float stepCycle;
    private float nextStep;
    private Vector2 input;

    public float unitPerSec = 4f;

    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
        originalCameraPosition = camera.transform.localPosition;
        headBob.Setup(camera, stepInterval);
        stepCycle = 0f;
        nextStep = stepCycle / 2f;
        mouseLook = new MouseLook
        {
            smooth = true,
            smoothTime = 2f
        };
        mouseLook.Init(transform, camera.transform);
    }

    // Update is called once per frame
    void Update()
    {
        float speed = unitPerSec * Time.deltaTime;
        //RotateView();
        Vector3 translation = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))//haut
        {
            translation.z += speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))//bas
        {
            translation.z -= speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))//gauche
        {
            translation.x -= speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))//droite
        {
            translation.x += speed;
        }
        transform.Translate(translation, Space.World);
    }

    private void FixedUpdate()
    {
        mouseLook.UpdateCursorLock();
    }

    private void RotateView()
    {
        mouseLook.LookRotation(transform, camera.transform);
    }
}
