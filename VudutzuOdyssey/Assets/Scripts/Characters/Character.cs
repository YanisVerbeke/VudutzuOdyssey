using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    //Nom et stats du personnage
    public string characterName = "Ui";
    public int mvtSpeed;
    public int healthPoint;
    public int atk;
    public bool isFighting;
    public int moveLeft;


    public GameObject clickAnimation;

    public Character(string name, int mvtSpeed, int hp, int atk)
    {
        this.characterName = name;
        this.mvtSpeed = mvtSpeed;
        this.healthPoint = hp;
        this.atk = atk;
        moveLeft = mvtSpeed;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

     /**
     * Clone the piece P and set it up in the "futur" for it being tested,
     * made to avoid moving a piece and putting our own king in check.
     * @return the new object Piece p.
     */
    public Character clone()
    {
        Character p = new Character(this.characterName, this.mvtSpeed, this.healthPoint, this.atk);
        return p;
    }

    
}
