using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{

    [SerializeField] private string scene;
    // Start is called before the first frame update

    // Update is called once per frame


    public Button yourButton;

    public void Navigation(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void EndGame()
    {
        Application.Quit();
        Debug.Log("You have clicked the button!");
    }
}
