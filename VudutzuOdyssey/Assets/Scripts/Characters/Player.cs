using UnityEngine;
using System.Collections;

public class Player : Character
{
    public Player(string name, int mvtSpeed, int hp, int atk) : base(name, mvtSpeed, hp, atk)
    {
    }
    // Use this for initialization
    void Start()
    {
        isFighting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFighting)
        {
            PlayerMovement.UserMovement(mvtSpeed, clickAnimation);
        }
    }
}
