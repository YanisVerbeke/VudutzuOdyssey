using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;
    private Vector3 Deplacement;
    public int MinX;
    public int MaxX;
    public int MinY;
    public int MaxY;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x > MinX && Player.transform.position.x < MaxX)
        {
            Deplacement = new Vector3(Player.transform.position.x, 0, 0) + offset;
            //transform.position = Player.transform.position + offset;
        }
        if (Player.transform.position.y > MinY && Player.transform.position.y < MaxY)
        {
            Deplacement = new Vector3(0, Player.transform.position.y, 0) + offset;
        }

        transform.position = Deplacement;
    }
}
