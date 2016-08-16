using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    public Object explosion;
    private SpriteRenderer sr;
    public Score_Count sc;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet_red")
        {
            sc.add_score();
            Instantiate(explosion, new Vector3(transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
    void Start()
    {
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
            sr.material.color = new Color(sr.material.color.r, sr.material.color.g, sr.material.color.b, sr.material.color.a - 0.005f);
        }
    }
}
