using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Main_Menu : MonoBehaviour {

	public void Start_Game()
    {
        SceneManager.LoadScene(1);
    }

    public void Instructions()
    {
        SceneManager.LoadScene(2);
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
