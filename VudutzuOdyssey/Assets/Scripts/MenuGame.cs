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

    void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.name == "Player" )
        {
            Debug.Log("tedst");
            Navigation(scene);
        }
    }

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
