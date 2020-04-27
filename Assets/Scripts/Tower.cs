using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject BulletPref;
    public float BulletTime;
    GameObject ship;
    Transform gun_pos;
    Bullet bulletscript;


    private void Start()
    {
        ship = GameObject.Find("Player");
        gun_pos = transform.GetChild(0).GetChild(0);
        bulletscript = BulletPref.GetComponent<Bullet>();

        StartCoroutine(Shot());

    }
    private void Update()
    {
        if (ship)
        {
            //Vector2 temp = transform.GetChild(0).transform.position - ship.transform.position;
            Vector2 direction = ship.transform.position - transform.position;

            bulletscript.bulldir = direction;

            direction = direction.normalized;

            transform.GetChild(0).transform.rotation = 
                Quaternion.Euler(new Vector3(0, 0, -Vector2.Angle(new Vector2(Mathf.Clamp(direction.x, -1f, -0.3f),
                Mathf.Clamp(direction.y, 0.1f, 1f)).normalized, -Vector2.right)));

            
            
        }

    }

    IEnumerator Shot()
    {
        //тут нужен цикл. и нужно перемещать пулю как то... в апдейте наверное... либо из куратины доставай гейм обжект
        // либо в префаб пули передавй веткор направление... хз пока как
        while (ship)
        {
            GameObject bullet = Instantiate(BulletPref, gun_pos.position, Quaternion.identity);
            yield return new WaitForSeconds(BulletTime);
        }

    }
}
