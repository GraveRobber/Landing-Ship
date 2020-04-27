using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject Player;
    Rigidbody2D playerRB;
    Quaternion originrotate;

    // по умолчанию anglefoce = 100, anglelimit = 0.45
    // что бы увеличть чувствительность первое умножили на 2, второе разделили... на 2))
    public float angleforce;
    public float anglelimit;



    private void Start()
    {
        playerRB = Player.GetComponent<Rigidbody2D>();
        originrotate = Player.transform.rotation;
        //temp = 0;
    }
    

    private void FixedUpdate()
    {
        

        if (Player != null)
        {
            if (Input.touchCount != 0)
            {
                playerRB.AddForce(Player.transform.up * 20);
            }

            float angle = Input.acceleration.x;
            Quaternion rotationZ = Quaternion.AngleAxis
                (-Mathf.Clamp(angle, -anglelimit, anglelimit) * angleforce, new Vector3(0, 0, 1));
            Player.transform.rotation = originrotate * rotationZ;
        }

    }

    private void Update()
    {
    }

    


}
