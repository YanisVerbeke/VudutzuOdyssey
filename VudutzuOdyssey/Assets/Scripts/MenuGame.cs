using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public Vector3 pos1;
    [SerializeField] private string scene;
    // Start is called before the first frame update

    // Update is called once per frame


    public void Start()
    {
        pos1 = GameObject.FindWithTag("PlayerFight Variant").transform.position;
        pos1.x = 0;
        pos1.y = 0;
    }

    public Button yourButton;

    void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.name == "PlayerFight Variant")
        {
            
            Navigation(scene);
            pos1 = GameObject.FindWithTag("PlayerFight Variant").transform.position;
            pos1.x = 0;
            pos1.y = 0;
            Debug.Log("tedst");
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
