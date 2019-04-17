using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{

    public enum e_player{Left,Right}
    public e_player player;
    public float speed = 5f;
    public Vector3 vec;
    public GameObject playerObj;

    private Rigidbody rbody;


    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Rotate();
        vec = this.transform.rotation.eulerAngles;
    }


    private void Shoot()
    {
        GameObject obj = Instantiate(playerObj,this.transform.position,this.transform.rotation,this.transform);
        obj.transform.SetParent(null);
        obj.GetComponent<Player>().LaunchPlayer();
    }

    private void Rotate()
    {
        if(player == e_player.Left)
        {
            if (Input.GetKey(KeyCode.W) && vec.y >= 225)
            {
                this.transform.Rotate(Vector3.down * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S) && vec.y <= 315)
            {
                this.transform.Rotate(Vector3.up * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                Shoot();
            }

        }
        else
        {

        }
    }

    


}
