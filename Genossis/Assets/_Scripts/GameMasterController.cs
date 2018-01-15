using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class GameMasterController : NetworkBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] AudioListener audioListener;

    int mode = 0;//god or ghost
    public float unitPerSec = 4f;

    List<GameObject> players;
    int numPlayers;

    private void Start()
    {
        numPlayers = Network.connections.Length;

        for(int i =2;i<numPlayers;i++)
        {
            players.Add(GameObject.Find("Player" + i));
        }
    }

    void Update()
    {
        if(numPlayers < Network.connections.Length)
        {
            numPlayers = Network.connections.Length;

            players.Add(GameObject.Find("Player" + numPlayers));
        }

        if (mode == 0 && Input.GetKeyDown(KeyCode.F1))//switch to god mod
        {
            GetComponent<CharacterController>().enabled = false;
            GetComponent<FirstPersonController>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            audioListener.enabled = false;
            mode = 1;
            Debug.Log("DEACTIVATE");
            InitialiseMJ();
        }
        else if (mode == 1 && Input.GetKeyDown(KeyCode.F1))
        {
            
            GetComponent<CharacterController>().enabled = true;
            GetComponent<FirstPersonController>().enabled = true;
            GetComponent<Rigidbody>().useGravity = true;
            audioListener.enabled = true;
            mode = 0;
            camera.orthographic = false;
            Debug.Log("ACTIVATE");
            Cursor.visible = false;
        }
        MovementGod();
        ZoomGod();
        GoToPlayer();
    }

    private void InitialiseMJ()
    {
        Vector3 position;

		position.x = transform.position.x;
		position.z = transform.position.y;
        position.y = 200;

        camera.orthographic = true;
        camera.orthographicSize = 20;
        camera.transform.rotation = Quaternion.Euler(90,0,0);

        transform.position = position;
    }

    private void MovementGod()
    {
        if (mode== 1)
        {
            Cursor.visible = true;

            Vector3 translation = Vector3.zero;
            float speed = unitPerSec * Time.deltaTime;

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

    public void ZoomGod()
    {
        if (mode == 1)
        {
            Cursor.visible = true;
            float speed = unitPerSec * Time.deltaTime;

            if (camera.orthographicSize > 1 
                && Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                camera.orthographicSize--;
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                camera.orthographicSize++;
            }
        }
    }

    public void GoToPlayer()
    {
        if(mode== 1)
        {
            if(Input.GetMouseButtonDown(1))
            {
                Vector3 position = 
                    new Vector3(Input.mousePosition.x,Input.mousePosition.z);

                foreach (GameObject player in players)
                {
                    if(player.transform.position.x > position.x
                        && player.transform.position.x < position.x + 10
                        && player.transform.position.y > position.y
                        && player.transform.position.y < position.y + 10)
                    {
                        transform.position = position;
                    }
                }
                transform.position = position;
            }
        }
    }
}
