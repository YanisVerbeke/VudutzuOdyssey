using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoad : MonoBehaviour
{

    MenuGame menuGame;
    // Start is called before the first frame update
    void Start()
    {
        SetTransform(3, 3);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetTransform(float x, float y)
    {
        transform.position = new Vector3(x, y, -2.0f);
    }
}
