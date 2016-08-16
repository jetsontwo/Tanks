using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour {

    public GameObject instructions;

	public void Start_Game()
    {
        SceneManager.LoadScene(1);
    }

    public void Instructions()
    {
        instructions.SetActive(true);
    }
}
