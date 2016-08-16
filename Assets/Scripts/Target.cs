using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    public Object explosion;
    private SpriteRenderer sr;
    private GameObject UI_holder;
    private Game_UI GUI;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet_red")
        {
            Instantiate(explosion, new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
            Destroy(gameObject);
            GUI.add_score();
        }
    }
    void Start()
    {
        UI_holder = GameObject.FindGameObjectWithTag("MainCamera");
        GUI = UI_holder.GetComponent<Game_UI>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    void LateUpdate()
    {
        if(sr.material.color.a <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            sr.material.color = new Color(sr.material.color.r, sr.material.color.g, sr.material.color.b, sr.material.color.a - 0.002f);
        }
    }
}
