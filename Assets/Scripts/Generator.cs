using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] ground;
    public GameObject midle_ground;

    public GameObject plant;

    public GameObject tower;
    public float towernum;

    //GameObject temp;

    public int ground_deep;
    public int ground_length;
    public int ground_height;

    Vector3 left_bodom;

    private void Awake()
    {
        left_bodom = Camera.main.ViewportToWorldPoint(Vector3.zero);
        //RandomGenerator();
        RandomLandGen();
        PlantInst();
        PlantTowe();

    }

    public void RandomLandGen()
    {
        float pos_x = Mathf.Round(left_bodom.x);
        float pos_y = Mathf.Round(left_bodom.y);
        Vector2 pos = new Vector2(pos_x - 0.5f, pos_y + 0.5f);
        int i = 0;

        int midle_count = ground_deep;

        while (i < ground_length)
        {

            //GameObject temp = Instantiate(ground[Random.Range(0, 3)], pos, Quaternion.identity, this.transform);
            GameObject temp = Inst_ground(pos, ref midle_count);

            i++;

            if (temp.name == "2(Clone)")
            {
                temp.transform.position = temp.transform.position + new Vector3(0, 1, 0);
                pos += new Vector2(0, 1);

                midle_count++;

                Midle_ground_pos(temp, midle_count);
            }

            if (temp.name == "3(Clone)")
            {
                pos -= new Vector2(0, 1);
                Midle_ground_pos(temp, midle_count);

                midle_count--;
            }

            pos += new Vector2(1, 0);
            Midle_ground_pos(temp, midle_count);
            

        }

    }

    GameObject Inst_ground(Vector2 pos, ref int n)
    {
        if (n == 0)
        {
            GameObject temp = Instantiate(ground[Random.Range(0,2)], pos, Quaternion.identity, this.transform);
            
            return temp;
        }
        if (n == ground_height)
        {
            int z = Random.Range(0, 2);

            if (z == 1)
            {
                GameObject temp = Instantiate(ground[0], pos, Quaternion.identity, this.transform);
                return temp;
            }
            else
            {
                GameObject temp = Instantiate(ground[2], pos, Quaternion.identity, this.transform);
                return temp;
            }

        }
        else
        {
            GameObject temp = Instantiate(ground[Random.Range(0, 3)], pos, Quaternion.identity, this.transform);
            return temp;
        }
    }

    void Midle_ground_pos(GameObject temp, int test)
    {
        int i = 0;
        Vector3 pos = temp.transform.position;
        while (i<test)
        {
            Instantiate(midle_ground, pos - new Vector3(0,1,0),Quaternion.identity, transform.GetChild(0));
            pos -= new Vector3(0, 1, 0);
            i++;
        }
    }


    public void Clean()
    {
        for(int i=0; i < this.transform.GetChild(0).transform.childCount; i++)
        {
            Destroy(this.transform.GetChild(0).transform.GetChild(i).gameObject);
        }
        for(int i = 1; i<this.transform.childCount;i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }
        
    }

    void PlantInst()
    {
        //int n = Random.Range(this.transform.childCount / 2, this.transform.childCount - 5);
        int n = RandomNum();
        float plantpoasy = 0.75f;
        //while(this.transform.GetChild(n).gameObject.name == "3(Clone)")
        //{
        //    n--;
        //}
        if(this.transform.GetChild(n+1).gameObject.name == "2(Clone)")
        {
            plantpoasy += 1f;
        }
        Vector2 plantpos = new Vector2(this.transform.GetChild(n).gameObject.transform.position.x,
            this.transform.GetChild(n).gameObject.transform.position.y + plantpoasy);
        //GameObject temp = Instantiate(plant, plantpos, Quaternion.identity);
        Instantiate(plant, plantpos, Quaternion.identity);
        GameObject temp = Instantiate(plant, plantpos + Vector2.right, Quaternion.identity);
        temp.GetComponent<SpriteRenderer>().flipX = true;
    }

    void PlantTowe()
    {
        int check = 0;
        int n = 0;
        for(int i =0; i<towernum; i++)
        {
            if(check == n)
            {
                n = RandomNum();
            }
            check = n;
            
            Vector2 towerpos = new Vector2(this.transform.GetChild(n).gameObject.transform.position.x,
            this.transform.GetChild(n).gameObject.transform.position.y + 0.75f);
            Instantiate(tower, towerpos, Quaternion.identity);
        }
        

    }

    int RandomNum()
    {
        return Random.Range(this.transform.childCount / 2, this.transform.childCount - 5);
    }

    //это еще один варик генератора... он проверяет предыдущий кусок и исходя из этого строит следующий...
    //void RandomGenerator()
    //{
    //    float pos_x = Mathf.Round(left_bodom.x);
    //    float pos_y = Mathf.Round(left_bodom.y);
        
    //    Vector2 first_pos = new Vector2(pos_x -0.5f, pos_y+0.5f);

    //    Instantiate(ground[Random.Range(0,3)], first_pos, Quaternion.identity, this.transform);

    //    int i = 0;
        
    //    while(i<5)
    //    {

    //        Vector2 temp = this.transform.GetChild(i).transform.position;
    //        Vector2 new_pos = temp + new Vector2(1,0);

    //        if(this.transform.GetChild(i).name == "2(Clone)")
    //        {
    //            transform.GetChild(i).transform.position = temp + new Vector2(0,1);
    //            new_pos = new_pos + new Vector2(0, 1);
    //            Instantiate(ground[Random.Range(0, 2)], new_pos, Quaternion.identity, this.transform);
               
    //        }
    //        else if(this.transform.GetChild(i).name == "3(Clone)")
    //        {
    //            new_pos = new_pos - new Vector2(0, 1);
    //            Instantiate(ground[Random.Range(0, 3)], new_pos, Quaternion.identity, this.transform);
    //        }
    //        else
    //        {
    //            Instantiate(ground[Random.Range(0, 3)], new_pos, Quaternion.identity, this.transform);
    //        }

            
    //        i++;
    //    }
        
        

    //}
}
