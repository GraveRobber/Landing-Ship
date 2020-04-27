using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bullet_speed;
    public Vector2 bulldir;

    Vector2 topborder;

    private void FixedUpdate()
    {
        topborder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));

        bulldir = bulldir.normalized;

        transform.Translate(new Vector2(Mathf.Clamp(bulldir.x, -1f, -0.3f), Mathf.Clamp(bulldir.y, 0.1f, 1f)).normalized
            * Time.deltaTime * bullet_speed);


        if(this.transform.position.x < topborder.x || this.transform.position.y > topborder.y)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }


}
