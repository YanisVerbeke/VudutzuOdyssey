using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{


    // Start is called before the first frame update

    // Update is called once per frame
    

    public Button yourButton;

    void Start()
    {
    }

    void Update()
    {

    }

    public void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene("VillageScene");
    }

    public void EndGame()
    {
        Application.Quit();
        Debug.Log("You have clicked the button!");
    }
}
