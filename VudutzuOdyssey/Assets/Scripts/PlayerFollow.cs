using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;
    private Vector3 Deplacement;
    public int MinX;
    public int MaxX;
    public int MinY;
    public int MaxY;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ( (Player.transform.position.x > MinX && Player.transform.position.x < MaxX) && ( Player.transform.position.y > MinY && Player.transform.position.y < MaxY ))
        {
            Deplacement = new Vector3(Player.transform.position.x, Player.transform.position.y, 0) + offset;

        } else {
            if ( Player.transform.position.x <= MinX && Player.transform.position.y <= MinY){
                Deplacement = new Vector3(MinX, MinY, 0) + offset;
            }
            else if( Player.transform.position.x >= MaxX && Player.transform.position.y >= MaxY ){
                Deplacement = new Vector3(MaxX, MaxY , 0) + offset ;
            }
            else if( Player.transform.position.x <= MinX && Player.transform.position.y >= MaxY ){
                Deplacement = new Vector3(MinX, MaxY , 0) + offset ;
            }
            else if( Player.transform.position.x >= MaxX && Player.transform.position.y <= MinY ){
                Deplacement = new Vector3(MaxX, MinY , 0) + offset ;
            }
            else if ( Player.transform.position.x <= MinX){
                Deplacement = new Vector3( MinX ,Player.transform.position.y, 0) + offset;
            }
            else if( Player.transform.position.x >= MaxX){
                Deplacement = new Vector3( MaxX ,Player.transform.position.y, 0) + offset;
            }
            else if(Player.transform.position.y >= MaxY ){
                Deplacement = new Vector3(Player.transform.position.x, MaxY, 0) + offset;
            }
            else if(Player.transform.position.y <= MinY ){
                Deplacement = new Vector3(Player.transform.position.x, MinY, 0) + offset;
            }
        }
    

        /*
        if ( Player.transform.position.y > MinY && Player.transform.position.y < MaxY )
        {
            Deplacement = new Vector3(Player.transform.position.x, Player.transform.position.y, 0) + offset;
            Debug.Log( Player.transform.position.y+ " : POSITION_Y ");
        } else if( Player.transform.position.y <= MinY + 1){
            Deplacement = new Vector3(Player.transform.position.x, MinY, 0) + offset;
            transform.position = Deplacement;
            return;
        }
        else if( Player.transform.position.y >= MaxY - 1){
            Deplacement = new Vector3(Player.transform.position.x, MaxY, 0) + offset;
            transform.position = Deplacement;
            return;
        }
        */
        transform.position = Deplacement;
    }
}
