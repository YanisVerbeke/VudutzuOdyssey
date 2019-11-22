using UnityEngine;
using System.Collections;

public class Player : Character
{
    private Animator animator;
    public Vector2 direction;

    public Player(string name, int mvtSpeed, int hp, int atk) : base(name, mvtSpeed, hp, atk)
    {
    }
    // Use this for initialization
    void Start()
    {
        isFighting = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFighting)
        {
            PlayerMovement.UserMovement(mvtSpeed, clickAnimation);
        }
        direction = PlayerMovement.GetDirection();
        AnimateMovement(direction);
    }

    public void AnimateMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);

        animator.SetFloat("DirectionX", direction.x);
        animator.SetFloat("DirectionY", direction.y);
    }
}
