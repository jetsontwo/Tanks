using UnityEngine;
using System.Collections;

public class Bullet_Movement : MonoBehaviour {

    public float speed;
    private float time_passed, angle, wall, temp;
    private string cur_tag;
    private bool collided;
    private BoxCollider2D bc;

    void Start()
    {
        time_passed = 0;
        bc = GetComponent<BoxCollider2D>();
    }
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0,speed,0));
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        angle = transform.eulerAngles.z;
        cur_tag = c.tag;
        print(cur_tag);

        if(cur_tag == "wall_N" || cur_tag == "wall_W" || cur_tag == "wall_E" || cur_tag == "wall_S")
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
        }
        else if (cur_tag == "target")
        {
            Destroy(gameObject);
        }
        transform.eulerAngles = new Vector3(0,0,angle);
    }
}
