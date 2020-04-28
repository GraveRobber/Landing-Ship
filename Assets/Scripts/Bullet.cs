using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bullet_speed;

    Vector2 topborder;

    private void FixedUpdate()
    {
        topborder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));


        transform.Translate(Vector2.left * Time.deltaTime * bullet_speed);


        if(this.transform.position.x < topborder.x || this.transform.position.y > topborder.y)
        {
            Destroy(this.gameObject);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }


}
