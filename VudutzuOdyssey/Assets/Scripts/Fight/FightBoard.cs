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

    //private Character[,] board = new Character[yMax, xMax];

    [SerializeField]
    private GameObject playerObject;

    private static bool isMoving;
    private static Vector3 targetPosition;

    /**
     * This method clones a ChessBoard and all the pieces on it
     * @return a copy of the main ChessBoard with all pieces on place
     */
    /*
   public FightBoard clone()
   {

       FightBoard cloB = new FightBoard();
       for (int i = 0; i < yMax; i++)
       {
           for (int j = 0; j < xMax; j++)
           {
               cloB.board[i,j] = null;
               if (null != this.board[i,j])
               {
                   cloB.board[i,j] = this.board[i,j].clone();
               }
           }
       }
       return cloB;
   }

   public Character GetCharacter(Vector3 pos)
   {
       if (pos.x <= xMax && pos.x >= 0 && pos.y <= yMax && pos.y >= 0)
       {
           return this.board[(int)pos.y,(int)pos.x];
       }
       else
       {
           return null;
       }

   }

   public Player GetPlayer()
   {
       for(int i = 0; i < yMax; i++)
       {
           for (int j = 0; j < xMax; j++)
           {
               if (GetCharacter(new Vector3(j, i, 0)).GetType() == typeof(Player))
               {
                   return (Player)GetCharacter(new Vector3(j, i, 0));
               }
           }
       }
       return null;
   }

   */
    public int MoveCharacter(GameObject character, int mvtSpeed, int moveLeft)
    {
        /*List<Vector3> allPossibleMoves = GetPossibleMove(character.transform.position, this);
        foreach (Vector3 possibleMove in allPossibleMoves)
        {
            Debug.Log(possibleMove);
        }*/
        if (Input.GetMouseButtonUp(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = character.transform.position.z;
            targetPosition.x = (float)Math.Floor(targetPosition.x);
            targetPosition.y = (float)Math.Floor(targetPosition.y);

            if (moveLeft - ((int)Math.Abs(targetPosition.x - character.transform.position.x) + Math.Abs(targetPosition.y - character.transform.position.y)) >= 0)
            {
                Debug.Log("mvtSpeed > 0");
                if (targetPosition.x <= character.transform.position.x + mvtSpeed &&
                    targetPosition.x >= character.transform.position.x - mvtSpeed &&
                    targetPosition.y <= character.transform.position.y + mvtSpeed &&
                    targetPosition.y >= character.transform.position.y - mvtSpeed &&
                    (Math.Abs(targetPosition.x - character.transform.position.x) +
                (Math.Abs(targetPosition.y - character.transform.position.y)) <= mvtSpeed
                        )
                    )
                {
                    Debug.Log("isMoving is true");
                    isMoving = true;
                    moveLeft -= (int)(Math.Abs(targetPosition.x - character.transform.position.x) + (Math.Abs(targetPosition.y - character.transform.position.y)));
                    Debug.Log(moveLeft);
                }
                Debug.Log(targetPosition.x <= character.transform.position.x + mvtSpeed &&
                    targetPosition.x >= character.transform.position.x - mvtSpeed &&
                    targetPosition.y <= character.transform.position.y + mvtSpeed &&
                    targetPosition.y >= character.transform.position.y - mvtSpeed);
                Debug.Log(Math.Abs((targetPosition.x - character.transform.position.x) +
                (targetPosition.y - character.transform.position.y)));
                Debug.Log(Math.Abs((targetPosition.x - character.transform.position.x) +
                (targetPosition.y - character.transform.position.y)) <= mvtSpeed);
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
    /*
    public List<Vector3> GetPossibleMove(Vector3 pos, FightBoard board)
    {
        List<Vector3> listPossiblePos = new List<Vector3>();
        //int charaMoveLeft = (int)board.GetCharacter(pos).moveLeft;
        
        if (charaMoveLeft > 0)
        {

            possiblePos = new FightPosition(pos.x, pos.y - 2);
            if (possiblePos.x <= FightBoard.xMax && possiblePos.x >= 0 && possiblePos.y >= 0 && possiblePos.y <= FightBoard.yMax)
            {
                if (board.getCharacter(possiblePos) == null && board.getCharacter(new FightPosition(pos.x, pos.y - 1)) == null)
                {
                    ListPossiblePos.Add(possiblePos);
                }
            }
        }
        possiblePos = new FightPosition(pos.x, pos.y - 1);
        if (possiblePos.x <= 7 && possiblePos.x >= 0 && possiblePos.y >= 0 && possiblePos.y <= 7)
        {
            if (board.getCharacter(possiblePos) == null)
            {
                ListPossiblePos.Add(possiblePos);
            }
            for (int i = -1; i < 2; i += 2)
            {
                eatPos = new FightPosition(pos.x + i, pos.y - 1);
                if (board.getCharacter(eatPos) != null)
                {
                    if (!board.getCharacter(eatPos).getColor().equals(board.getCharacter(pos).getColor()))
                    {
                        ListPossiblePos.Add(eatPos);
                    }
                }
            }
        }
        listPossiblePos.AddRange(PossibleMoves.DiagonalMove(pos, board));
        listPossiblePos.AddRange(PossibleMoves.OrthogonalMove(pos, board));

        return listPossiblePos;
    }
    */
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
