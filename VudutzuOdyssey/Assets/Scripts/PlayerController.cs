using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour 
{
    public float speed = 10f;
    private Vector3 targetPosition;
    private bool isMoving;
    public GameObject clickAnimation;
 // Use this for initialization
 void Start () 
    {
 
 }
 
 // Update is called once per frame
 void Update () 
 {
        userMovement();
 }

    void userMovement()
    {
        if (Input.GetMouseButtonUp(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z;
            //Position camera X
            if (targetPosition.x < 0)
            {
                targetPosition.x = (int)targetPosition.x - 1;
            }
            else
            {
                targetPosition.x = (int)targetPosition.x;
            }

            //Position caméra Y
            if (targetPosition.y < 0)
            {
                targetPosition.y = (int)targetPosition.y - 1;
            }
            else
            {
                targetPosition.y = (int)targetPosition.y;
            }
            Debug.Log(Input.mousePosition.y + " entier : " + (int)targetPosition.y + " " + Camera.main.ScreenToWorldPoint(Input.mousePosition));            //Debug.Log("1 pos y : " + targetPosition.y + " //  pos x "+targetPosition.x);

            if (isMoving == false)
            {
                isMoving = true;
                //Instantiate(clickAnimation, targetPosition, Quaternion.identity);
            }
        }
        if (isMoving == true)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            //Debug.Log("pos y " + targetPosition.y);
        }
        if (targetPosition == transform.position)
        {
            isMoving = false;
            Destroy(GameObject.Find("Perso(Clone)"));
        }
    }
}