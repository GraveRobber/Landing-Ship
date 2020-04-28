using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followObject;
    public GameObject Ground;
    public float camanglelimit;

    float halfcamwidth;
    Generator temp;

    private void Start()
    {
        halfcamwidth = Camera.main.orthographicSize *  Screen.width / Screen.height;
        temp = Ground.GetComponent<Generator>();
    }

    private void Update()
    {

        if (followObject != null)
        {
            Vector3 followObjectPos = followObject.transform.position;
            this.gameObject.transform.position = new Vector3(
                Mathf.Clamp(followObjectPos.x, Ground.transform.GetChild(1).transform.position.x+halfcamwidth, 
                Ground.transform.GetChild(Ground.transform.childCount - 1).transform.position.x-halfcamwidth), 
                Mathf.Clamp(followObjectPos.y, Ground.transform.GetChild(0).transform.GetChild(temp.ground_height-1).transform.position.y + Camera.main.orthographicSize, 
                10f), -10);

            Quaternion camangele = Quaternion.AngleAxis(followObject.transform.rotation.z*camanglelimit, new Vector3(0, 0, 1));
            this.gameObject.transform.rotation = camangele;
        }

    }

}
