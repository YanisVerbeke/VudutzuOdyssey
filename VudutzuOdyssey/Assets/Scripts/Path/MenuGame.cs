using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    [SerializeField] private float xC;
    [SerializeField] private float yC;
    [SerializeField] private string scene;
    private bool HeNavigate = false;
    // Start is called before the first frame update

    // Update is called once per frame


    public void Start()
    {
        //SetTransform(xC ,yC);
    }

    public Button yourButton;

    void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.name == "PlayerFight Variant")
        {
            
            Navigation(scene);
            //SetTransform(xC, yC);
        }
    }

    public void SetTransform(float x, float y)
    {
        transform.position = new Vector3(x, y, -2.0f);
    }

    public void Navigation(string scene)
    {
        SceneManager.LoadScene(scene);
        this.HeNavigate = true;
        if (gameObject.name == "PlayerFight Variant" && this.HeNavigate == true)
        {
            SetTransform(5, 5);
            this.HeNavigate = false;
        }
    }

    public void EndGame()
    {
        Application.Quit();
        Debug.Log("You have clicked the button!");
    }
}
