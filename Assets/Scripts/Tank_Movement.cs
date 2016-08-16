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
                count += 1;
                if (count == 8)
                {
                    count = 0;
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
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
