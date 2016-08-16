using UnityEngine;
using System.Collections;

public class Random_Generation : MonoBehaviour {
    private float timer = 0, randx, randy;
    public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= 2.5)
        {
            randx = Random.Range(-6f, 6f);
            randy = Random.Range(-4f, 4f);

            Instantiate(target, new Vector3(randx, randy, 0), Quaternion.identity);
            timer = 0;
        }
	}
}
