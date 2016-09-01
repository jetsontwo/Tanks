using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game_UI : MonoBehaviour {

    private int score;
    public Text score_text, game_over_text, timer_text;
    public Button game_over_button;
    public Random_Generation rg;
    private float time;
    private bool can_score, can_count;

	// Use this for initialization
	void Start () {
        score = 0;
        can_score = true;
        can_count = true;
	}
	
	public void add_score()
    {
        if (can_score)
        {
            score = score + 1;
        }
    }

    public void game_over()
    {
        game_over_text.gameObject.SetActive(true);
        game_over_button.gameObject.SetActive(true);
        rg.can_spawn = false;
        can_score = false;
        can_count = false;
    }

    public void return_main_menu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        score_text.text = "Score: " + score;
        time += Time.deltaTime;
        if(time <= 60 && can_count)
        {
            timer_text.text = "Time Left: " + (int)(60 - time);
        }
        else
        {
            timer_text.text = "Time Left: 0";
        }
        if (time >= 60)
        {
            game_over();
            
        }
    }
}
