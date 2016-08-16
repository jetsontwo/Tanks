using UnityEngine;
using System.Collections;

public class Random_Generation : MonoBehaviour {
    private float timer = 0, randx, randy, spawn_time;
    private int count;
    public bool can_spawn;

    public GameObject target;
	// Use this for initialization
	void Start () {
        spawn_time = 2.5f;
        count = 0;
        can_spawn = true;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= spawn_time && can_spawn)
        {
            randx = Random.Range(-6f, 6f);
            randy = Random.Range(-4f, 4f);

            Instantiate(target, new Vector3(randx, randy, 0), Quaternion.identity);
            timer = 0;
            count += 1;
        }

        if(count == 5 && spawn_time > 1)
        {
            spawn_time -= 0.1f;
            count = 0;
        }
	}
}
