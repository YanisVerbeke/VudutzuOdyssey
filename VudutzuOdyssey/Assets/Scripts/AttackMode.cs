using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMode : MonoBehaviour
{
    public GameObject Player;
    float CoordX;
    float CoordY;
    // Start is called before the first frame update
    void Start()
    {
        CoordX = Player.transform.position.x;
        CoordY = Player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
