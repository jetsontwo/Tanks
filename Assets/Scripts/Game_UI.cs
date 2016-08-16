using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score_Count : MonoBehaviour {

    private int score;
    public Text t;
	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	public void add_score()
    {
        score = score + 1;
    }

    void Update()
    {
        t.text = "Score:" + score;
    }
}
