using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Character : MonoBehaviour
{
    //Nom et stats du personnage
    public string characterName = "Ui";
    public int mvtSpeed;
    [SerializeField]  public int healthPoint;
    public int atk;
    public bool isFighting;
    public int moveLeft;

    /*public int GetHealthPoint()
    {
        return GetHealthPoint;
    }

    public void SetHealthPoint(int value)
    {
        GetHealthPoint = value;
        if (GetHealthPoint < 0) GetHealthPoint = 0;

    }*/

   

    public GameObject clickAnimation;

    public Character(string name, int mvtSpeed, int hp, int atk)
    {
        this.characterName = name;
        this.mvtSpeed = mvtSpeed;
        this.healthPoint = hp;
        this.atk = atk;
        moveLeft = mvtSpeed;
    }

    public void dealDamage(int atk)
    {
        healthPoint -= atk;
    }

    // Use this for initialization
    void Start()
    {
    }
    
}
