using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float unitPerSec = 0.5f;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        float speed = unitPerSec * Time.deltaTime;

        Movement(speed);
    }

    void Movement(float speed)
    {
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
}
