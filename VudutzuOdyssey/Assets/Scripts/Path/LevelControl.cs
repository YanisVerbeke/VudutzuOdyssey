using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    //public int index;
    public string levelName;

    // Start is called before the first frame update

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Perso")
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
