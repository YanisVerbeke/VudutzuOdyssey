using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PlayerMovement
{
    public static bool isMoving;
    private static Vector3 targetPosition;
    public static Vector2 direction;

    //Cette fonction permet le déplacement du personnage hors combat
    public static void UserMovement(float speed, GameObject clickAnimation)
    {
        if (Input.GetMouseButtonUp(0))
        {
            
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (clickAnimation != null)
            {
                targetPosition.z = clickAnimation.transform.position.z;
            }

            //Le repositionnement de la caméra permet le non-tremblement de celle-ci lors d'une collision

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

            //Le personnage est en mouvement, isMoving passe donc à true
            if (!isMoving)
            {
                isMoving = true;
            }
        }

        //Si le personnage est en mouvement, alors on va le déplacer vers la position voulue
        if (isMoving)
        {
            direction = Vector2.zero;
            if (clickAnimation != null)
            {
                if (targetPosition.y > clickAnimation.transform.position.y)
                {
                    direction += Vector2.up;
                }
                if (targetPosition.x < clickAnimation.transform.position.x)
                {
                    direction += Vector2.left;
                }
                if (targetPosition.y < clickAnimation.transform.position.y)
                {
                    direction += Vector2.down;
                }
                if (targetPosition.x > clickAnimation.transform.position.x)
                {
                    direction += Vector2.right;
                }

                clickAnimation.transform.position = Vector3.MoveTowards(clickAnimation.transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
        Debug.Log("1 : " + targetPosition);
        Debug.Log("2 : " + clickAnimation.transform.position);
        //Quand le personnage atteint la position voulue, isMoving repasse à false
        if (clickAnimation != null)
        {
            isMoving &= targetPosition != clickAnimation.transform.position;
        }
    }

    public static Vector2 GetDirection()
    {

        return direction;
    }
}