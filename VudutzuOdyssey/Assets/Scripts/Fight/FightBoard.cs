using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

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
    private int calculPosition;
    private int moveLeft;

    [SerializeField]
    private GameObject playerObject;

    private Vector3 targetPosition;

    private bool isMoving;
    private bool movementOver;
    private bool attackOver;
    private bool playerTurn;
    private bool isMoveActive;

    [SerializeField]
    private Text mouvementRestant;

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
                calculPosition = (int)(Math.Abs(targetPosition.x - character.transform.position.x) + Math.Abs(targetPosition.y - character.transform.position.y));

                if (moveLeft - calculPosition >= 0)
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
                        moveLeft -= calculPosition;
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
        if (targetPosition == character.transform.position)
        {
            isMoving = false;
            if (moveLeft == 0)
            {
                this.movementOver = true;
            }
        }

        return moveLeft;
    }

    public void TriggerMove()
    {
        isMoveActive = !isMoveActive;

        Debug.Log(mouvementRestant.text);
    }

    private void UpdateMovementText()
    {
        if (isMoveActive)
        {
            mouvementRestant.text = moveLeft + " Mouvement Restant";
        }
        else
        {
            mouvementRestant.text = "";
        }
    }

    private void Start()
    {
        Player player = (Player)playerObject.gameObject.GetComponent(typeof(Player));
        player.moveLeft = player.mvtSpeed;
        playerTurn = true;
        attackOver = true;
    }

    private void Update()
    {
        Player player = (Player)playerObject.gameObject.GetComponent(typeof(Player));
        //player.moveLeft = MoveCharacter(playerObject, player.mvtSpeed, player.moveLeft);
        if (playerTurn && isMoveActive)
        {
            player.moveLeft = MoveCharacter(playerObject, player.mvtSpeed, player.moveLeft);
        }

        //Attribution de moveLeft afin de l'afficher lors de l'activation du déplacement
        moveLeft = player.moveLeft;
        //Affichage dans l'update afin de rafraichir les données affichées
        UpdateMovementText();

        //Changement de tour et reset du mouvement et de l'attaque pour le nouveau tour
        if (movementOver && attackOver)
        {
            playerTurn = !playerTurn;
            attackOver = false;
            movementOver = false;
            Debug.Log(playerTurn);
        }
    }
}
