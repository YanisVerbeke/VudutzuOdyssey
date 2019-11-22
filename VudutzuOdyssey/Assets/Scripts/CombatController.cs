using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CombatController : MonoBehaviour
{
    [SerializeField] private string scene;

    private Vector3 targetPosition;
    private string attaque;
    private bool isCac = false;
    private bool isDistance = false;
    private Vector3 playerCoord;
    private Vector3 enemyCoord;

    public GameObject enemy;
    public GameObject player;
    public Character chPlayer;
    public Character chEnemy;
    

    //private bool isDistance= false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckIfFight(attaque);
    }

    public void CheckIfFight(string attaque)
    {

        if (Input.GetMouseButtonUp(0))
        {
            if (attaque == "cac")
            {
                isCac = true;
                Debug.Log("true");
            }
            else if (attaque == "distance")
            {
                isDistance = true;
            }

            //Debug.Log(isCac + " l'attaque " + attaque);
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerCoord = Round(player.transform.position);
            enemyCoord = Round(enemy.transform.position);

            if (Round(targetPosition).x == enemyCoord.x && Round(targetPosition).y == enemyCoord.y)
            {

                if (CheckRange(1) && isCac == true)
                {
                        Fight();
                    
                }else if (CheckRange(3) && isDistance == true)
                {
                    Fight(2);

                }

            }
            //Debug.Log("position player " + playerCoord + " et le mechant "+ enemyCoord);
            //Debug.Log("LOl mdr target position " + Round(targetPosition));
        }

    }

    public bool CheckRange(int valueRange)
    {
        if (playerCoord.x - valueRange <= enemyCoord.x  ||
            playerCoord.x + valueRange >= enemyCoord.x  ||
            playerCoord.y + valueRange >= enemyCoord.y  ||
            playerCoord.y - valueRange <= enemyCoord.y 
            )
        {
            Debug.Log(playerCoord+" vs "+ enemyCoord );
            return true;
        }
        else {
            return false;
        }
        
    }


    public void Fight(int mod = 0)
    {
        chEnemy.dealDamage(chPlayer.atk - mod);
        if (chEnemy.healthPoint <= 0)
        {
            SceneManager.LoadScene(scene);
        }
        else if (chPlayer.healthPoint <= 0)
        {
            SceneManager.LoadScene("scDead");
        }
        isCac = false;
        isDistance = false;
    }


    public Vector3 Round(Vector3 target)
    {

        target.x = (int)target.x;
        target.y = (int)target.y;
        return target;
    }

}
