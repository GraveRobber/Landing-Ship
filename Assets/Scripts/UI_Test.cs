using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Test : MonoBehaviour
{
    public Image SpeedImage, HightImage;
    float maxspeed;

    public Image LeftAngle, RightAngle;


    GameObject Player;
    Rigidbody2D PlayerRB;
    Player PlayerSript;
    Text speed, angle, hight;

    private void Start()
    {
        Player = this.transform.parent.gameObject;
        PlayerSript = Player.GetComponent<Player>();
        PlayerRB = Player.GetComponent<Rigidbody2D>();
        speed = this.transform.GetChild(0).GetComponent<Text>();
        angle = this.transform.GetChild(1).GetComponent<Text>();
        hight = this.transform.GetChild(2).GetComponent<Text>();
        maxspeed = PlayerSript.minspeed * 3;

        hight.color = Color.white;
        
    }
    private void Update()
    {
        this.transform.rotation = Camera.main.transform.rotation;

        speed.text = "Speed: " + Mathf.Round(PlayerRB.velocity.magnitude * 100);
        SpeedImage.fillAmount =  PlayerRB.velocity.magnitude/maxspeed;

        hight.text = "Hight: " + Mathf.Round (PlayerSript.GetHit.distance * 10);
        HightImage.fillAmount = Mathf.Round(PlayerSript.GetHit.distance * 10)/ (PlayerSript.maxhight * 1.2f);

        var temp = Mathf.Abs(Vector3.Dot(Vector3.right, Player.transform.up))* 100/ 1.577777777777778f;
        angle.text = "Angle: " + Mathf.Round(temp);
        //angle.text = "Angle: " + Mathf.Round(Vector3.Dot(Vector3.right, Player.transform.up) * 100);

        if(Mathf.Round(PlayerSript.GetHit.distance * 10) > PlayerSript.maxhight)
        {
            hight.color = Color.red;
            HightImage.color = Color.red;
        }
        else
        {
            hight.color = Color.white;
            HightImage.color = Color.green;
        }

        if(Vector3.Dot(Vector3.right, Player.transform.up) < 0)
        {
            LeftAngle.fillAmount = Vector3.Dot(Vector3.right, Player.transform.up) / - 0.45f;
            RightAngle.fillAmount = 0;
        }
        else if(Vector3.Dot(Vector3.right, Player.transform.up) == 0)
        {
            LeftAngle.fillAmount = RightAngle.fillAmount = 0;
        }
        else
        {
            RightAngle.fillAmount = Vector3.Dot(Vector3.right, Player.transform.up) / 0.45f;
            LeftAngle.fillAmount = 0;
        }

        if (PlayerRB.velocity.magnitude > PlayerSript.minspeed)
        {
            //SpeedImage.fillAmount = PlayerRB.velocity.magnitude / maxspeed;
            SpeedImage.color = Color.red;
            speed.color = Color.red;
        }
        else
        {
            //SpeedImage.fillAmount = PlayerRB.velocity.magnitude / 0.5f;
            speed.color = Color.white;
            SpeedImage.color = Color.green;
        }
        if (temp > PlayerSript.plantangle * 100)
        {
            LeftAngle.color = Color.red;
            RightAngle.color = Color.red;
            angle.color = Color.red;
        }
        else
        {
            LeftAngle.color = Color.green;
            RightAngle.color = Color.green;
            angle.color = Color.white;
        }

       
    }
}
