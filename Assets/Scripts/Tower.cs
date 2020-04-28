using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject BulletPref;
    public float BulletTime;
    GameObject ship;
    Transform gun_pos;
    Transform gun_axsis;


    private void Start()
    {
        ship = GameObject.Find("Player");
        gun_pos = transform.GetChild(0).GetChild(0);
        gun_axsis = transform.GetChild(0);

        StartCoroutine(Shot());
    }
    private void Update()
    {
        if (ship)
        {
            Vector2 direction = ship.transform.position - gun_pos.position;

            direction = direction.normalized;

            gun_axsis.rotation = 
                Quaternion.Euler(new Vector3(0, 0, -Vector2.Angle(new Vector2(Mathf.Clamp(direction.x, -1f, -0.3f),
                Mathf.Clamp(direction.y, 0f, 1f)).normalized, -Vector2.right)));

        }

    }

    IEnumerator Shot()
    {
        while (ship)
        {
            if (ship.transform.position.x < this.transform.position.x)
            {
                GameObject bullet = Instantiate(BulletPref, gun_pos.position, gun_axsis.rotation);
            }
            yield return new WaitForSeconds(BulletTime);
        }

    }
}
