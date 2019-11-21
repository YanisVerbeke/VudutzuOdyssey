using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class FightBoard : MonoBehaviour
{

    [SerializeField]
    public int xMax;
    [SerializeField]
    public int yMax;
    [SerializeField]
    public int xMin;
    [SerializeField]
    public int yMin;

    [SerializeField]
    private GameObject playerObject;

    private static bool isMoving;
    private static Vector3 targetPosition;

    public int MoveCharacter(GameObject character, int mvtSpeed, int moveLeft)
    {
        if (Input.GetMouseButtonUp(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (targetPosition.x <= xMax && targetPosition.x >= xMin && targetPosition.y <= yMax && targetPosition.y >= yMin)
            {
                targetPosition.z = character.transform.position.z;
                targetPosition.x = (int)Math.Floor(targetPosition.x);
                targetPosition.y = (int)Math.Floor(targetPosition.y);

                if (moveLeft - ((int)Math.Abs(targetPosition.x - character.transform.position.x) + Math.Abs(targetPosition.y - character.transform.position.y)) >= 0)
                {
                    if (targetPosition.x <= character.transform.position.x + mvtSpeed &&
                        targetPosition.x >= character.transform.position.x - mvtSpeed &&
                        targetPosition.y <= character.transform.position.y + mvtSpeed &&
                        targetPosition.y >= character.transform.position.y - mvtSpeed &&
                        (Math.Abs(targetPosition.x - character.transform.position.x) +
                    (Math.Abs(targetPosition.y - character.transform.position.y)) <= mvtSpeed
                            )
                        )
                    {
                        isMoving = true;
                        moveLeft -= (int)(Math.Abs(targetPosition.x - character.transform.position.x) + (Math.Abs(targetPosition.y - character.transform.position.y)));
                    }
                }
                else
                {
                    isMoving = false;
                }
            }
            else
            {
                isMoving = false;
            }
        }
        if (isMoving)
        {
            character.transform.position = Vector3.MoveTowards(character.transform.position, targetPosition, mvtSpeed * Time.deltaTime);
        }
        isMoving &= targetPosition != character.transform.position;

        return moveLeft;
    }

    private void Start()
    {
        Player player = (Player)playerObject.gameObject.GetComponent(typeof(Player));
        player.moveLeft = player.mvtSpeed;
    }

    private void Update()
    {
        Player player = (Player)playerObject.gameObject.GetComponent(typeof(Player));
        player.moveLeft = MoveCharacter(playerObject, player.mvtSpeed, player.moveLeft);
    }
}
