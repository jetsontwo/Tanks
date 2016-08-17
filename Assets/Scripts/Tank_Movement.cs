using UnityEngine;
using System.Collections;

public class Tank_Movement : MonoBehaviour {

    public float speed;
    private float moveVert;
    private int count = 0, wait_ticks = 0;
    private bool can_count = false;
    private SpriteRenderer sr;
    public string moveleft, moveright, moveforward, moveback, hurt_by_bullet;
    public Sprite[] sprites;
    public Game_UI GUI;
    public ParticleSystem explosion;
    public GameObject broken_tank, broken_tank_top;
    private Transform turret_trans;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        can_count = false;
        if (Input.GetKey(moveleft))
        {
            transform.Rotate(new Vector3(0, 0, 0.9f));
            can_count = true;
        }
        else if (Input.GetKey(moveright))
        {
            transform.Rotate(new Vector3(0, 0, -0.9f));
            can_count = true;
        }
        if (Input.GetKey(moveforward))
        {
            moveVert = 1 * Time.deltaTime;
            can_count = true;
        }
        if (Input.GetKey(moveback))
        {
            moveVert = -1 * Time.deltaTime;
            can_count = true;
        }
        
        if(!Input.GetKey(moveforward) && !Input.GetKey(moveback))
        {
            if(moveVert >= 0.001)
            {
                moveVert -= 0.001f;
            }
            else
            {
                moveVert = 0;
            }
            
        }
        
        transform.Translate(new Vector3(moveVert,0, 0));

        if (can_count)
        {
            if (wait_ticks > 1)
            {
                if(moveVert < 0)
                {
                    count += 1;
                    if (count >= 7)
                    {
                        count = 0;
                    }
                }
                else if(moveVert > 0)
                {
                    count -= 1;
                    if (count <= 0)
                    {
                        count = 7;
                    }
                }
                wait_ticks = 0;
            }
            wait_ticks += 1;
        }
        sr.sprite = sprites[count];
	}


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == hurt_by_bullet)
        {
            GUI.game_over();
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Instantiate(broken_tank, gameObject.transform.position, transform.rotation);
            Transform[] trans = GetComponentsInChildren<Transform>();
            foreach(Transform t in trans)
            {
                if (t.tag != "Player")
                {
                    turret_trans = t;
                }
            }
            GameObject turret = (GameObject)Instantiate(broken_tank_top, gameObject.transform.position, turret_trans.rotation);
            turret.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(col.transform.eulerAngles.z), Mathf.Sin(col.transform.eulerAngles.z));
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
