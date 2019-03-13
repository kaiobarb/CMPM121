using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public bool highlighted = false;
    [HideInInspector]
    public bool moving = false;
    public float movementSpeed = 2;
    private float hitpoints;
    private float strength;
    private float defense;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (moving)
            animator.SetBool("moving", true);
        else
            animator.SetBool("moving", false);
    }

    public void move(Transform destination)
    {
        float step = movementSpeed * Time.deltaTime;
        Vector3 pos = destination.position;
        Vector3 newPos = new Vector3(pos.x, transform.position.y, pos.z);
        transform.position = Vector3.MoveTowards(transform.position, newPos, step);
    }

    public void attack()
    {

    }

    public void takeDamage()
    {

    }
}
