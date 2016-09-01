using UnityEngine;
using System.Collections;

public class Bullet_Movement : MonoBehaviour {

    public float speed;
    private float angle, wall, temp;
    private string cur_tag;
    private bool collided;
    private int times_bounced = 0;

	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,speed,0));
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        angle = transform.eulerAngles.z;
        cur_tag = c.tag;

        /*
        Vector3 impactPosition = new Vector3(0.707,0.707,0);
        Vector3 impactNormal;

        Ax + By + Cz + D = 0;

        y = x 
        */

        if (cur_tag == "wall_N" || cur_tag == "wall_W" || cur_tag == "wall_E" || cur_tag == "wall_S" && times_bounced < 4)
        {
            if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z < 90)
            {
                if (cur_tag == "wall_N")
                {
                    wall = 90;
                }
                else if (cur_tag == "wall_W")
                {
                    wall = 0;
                }
                temp = wall - angle;
                angle = temp + wall;
            }
            else if (transform.eulerAngles.z >= 90 && transform.eulerAngles.z < 180)
            {
                if (cur_tag == "wall_W")
                {
                    wall = 180;
                }
                else if (cur_tag == "wall_S")
                {
                    wall = 90;
                }
                temp = wall - angle;
                angle = temp + wall;

            }
            else if (transform.eulerAngles.z >= 180 && transform.eulerAngles.z < 270)
            {
                if (cur_tag == "wall_S")
                {
                    wall = 270;
                }
                else if (cur_tag == "wall_E")
                {
                    wall = 180;
                }
                temp = wall - angle;
                angle = temp + wall;

            }
            else if (transform.eulerAngles.z >= 270 && transform.eulerAngles.z < 360)
            {
                if (cur_tag == "wall_E")
                {
                    wall = 0;
                }
                else if (cur_tag == "wall_N")
                {
                    wall = 270;
                }
                temp = wall - angle;
                angle = temp + wall;

            }
            times_bounced += 1;
        }
        else if (cur_tag == "target" || times_bounced >= 4)
        {
            Destroy(gameObject);
        }
        transform.eulerAngles = new Vector3(0,0,angle);
    }
}
