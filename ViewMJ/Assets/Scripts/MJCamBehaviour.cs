using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJCamBehaviour : MonoBehaviour {

    //
    // VARIABLES
    //

    public float unitPerSec = 4f;

    void Update()
    {
        float speed = unitPerSec * Time.deltaTime;

        Camera cam = GetComponent<Camera>();

        Vector3 translation = Vector3.zero;

        if (Input.GetKey(KeyCode.W))//haut
        {
            translation.z += speed;
        }
        if (Input.GetKey(KeyCode.S))//bas
        {
            translation.z -= speed;
        }
        if (Input.GetKey(KeyCode.A))//gauche
        {
            translation.x -= speed;
        }
        if (Input.GetKey(KeyCode.D))//droite
        {
            translation.x += speed;
        }
        transform.Translate(translation, Space.World);

        if (cam.orthographicSize > 1 && Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            cam.orthographicSize--;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            cam.orthographicSize++;
        }
    }
}
