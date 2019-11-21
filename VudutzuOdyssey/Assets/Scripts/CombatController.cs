using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CombatController : MonoBehaviour
{

    private Vector3 targetPosition;
    public GameObject enemy;
    public GameObject player;
    [SerializeField] private string attaque;
    private bool isCac= false;
    private bool isDistance= false;

    //public string attaque = "cac";

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
            //attaque = "cac";

            Debug.Log("l'attaque "+attaque);
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 enemyCoord = Round(enemy.transform.position);

            if (Round(targetPosition).x == enemyCoord.x && Round(targetPosition).y == enemyCoord.y)
            {
                if(isCac == true)
                {
                    Debug.Log("nice");
                }
                else if(attaque == "distance")
                {
                    Debug.Log("nice");
                }
                
            }
            
            Vector3 playerCoord = Round(player.transform.position);
            Debug.Log("position player " + playerCoord + " et le mechant "+ enemyCoord);
            Debug.Log("LOl mdr target position " + Round(targetPosition));
        }
    }

    public Vector3 Round(Vector3 target)
    {

            target.x = (int)target.x ;
            target.y = (int)target.y;
        Debug.Log("position x  " + target.x);
        return target;
    }

}
