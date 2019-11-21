using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PlayerMovement
{
    private static bool isMoving;
    private static Vector3 targetPosition;

    //Cette fonction permet le déplacement du personnage hors combat
    public static void UserMovement(float speed, GameObject clickAnimation)
    {
        if (Input.GetMouseButtonUp(0))
        {
            
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = clickAnimation.transform.position.z;

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
            clickAnimation.transform.position = Vector3.MoveTowards(clickAnimation.transform.position, targetPosition, speed * Time.deltaTime);
        }

        //Quand le personnage atteint la position voulue, isMoving repasse à false
        isMoving &= targetPosition != clickAnimation.transform.position;
    }
}