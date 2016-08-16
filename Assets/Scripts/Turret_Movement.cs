using UnityEngine;
using System.Collections;

public class Turret_Movement : MonoBehaviour {

    public GameObject empty_spawn;
    public GameObject bullet_orig;
    private int shooter_timer;
    public string moveleft, moveright, shoot_key;
    public float turret_speed;
    public AudioSource shoot_sound;

    void Start()
    {
        shooter_timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(moveleft))
        {
            
            transform.Rotate(new Vector3(0, 0, turret_speed));
        }
        else if (Input.GetKey(moveright))
        {
            transform.Rotate(new Vector3(0, 0, -turret_speed));
        }

        if (Input.GetKey(shoot_key))
        {
            if(shooter_timer == 0)
            {
                shoot();
                shooter_timer = 30;
            }
        }
        
        if(shooter_timer > 0)
        {
            shooter_timer -= 1;
        }
    }

    void shoot()
    {
        shoot_sound.Play();
        var bullet = Instantiate(bullet_orig, empty_spawn.transform.position,transform.rotation * Quaternion.Euler(0, 0, 270));
    }
}
