using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InputManager inputscript;
    public float minspeed;
    public float plantangle;
    public float maxhight;
    public GameObject Shield;
    public int PlayerShieldCount;
    Rigidbody2D PlayerRB;
    RaycastHit2D hit;




    private void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        hit = Physics2D.Raycast((Vector2)this.transform.position - new Vector2(0f, 1.2f), -Vector2.up, 8);
        
    }
    private void Update()
    {
        //hit = Physics2D.Raycast((Vector2)this.transform.position - new Vector2(0f, 1.2f), -Vector2.up);
        //Debug.DrawRay((Vector2)this.transform.position - new Vector2(0f, 1.2f), -Vector2.up, Color.red, 10f);
        if(PlayerShieldCount <= 0)
        {
            Shield.SetActive(false);
        }
        else
        {
            Shield.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            Destroy(this.gameObject);
            print("FAIL");
        }

        if(collision.gameObject.tag == "Bullet")
        {
            PlayerShieldCount--;
            print(PlayerShieldCount);
            if(PlayerShieldCount < 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (collision.gameObject.tag == "Plant")
        {
            if (Mathf.Abs(Vector3.Dot(Vector3.right, this.transform.up)) > Mathf.Abs(plantangle))
            {
                Destroy(this.gameObject);
                print("WRONG ANGLE");
            }

            else if (PlayerRB.velocity.magnitude > minspeed)
            {
                Destroy(this.gameObject);
                print("TOO FAST");

            }

            else
            {
                Destroy(inputscript);
                transform.GetChild(0).gameObject.SetActive(false);
                print("WIN");
            }
        }
    }

    public RaycastHit2D GetHit
    {
        get
        {
            return hit;
        }
    }

}
