using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PnjController : MonoBehaviour
{
    public Text myText;
    public GameObject Panel;
    public string texte;
    // Start is called before the first frame update
    void Start()
    {
        Panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = texte;
    }
    void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.name == "Player")
        {
            Debug.Log("tedst");
            Panel.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Debug.Log("bye");
            Panel.gameObject.SetActive(false);
        }
    }

    public void HidePanel()
    {
        Panel.gameObject.SetActive(false);
    }
}
