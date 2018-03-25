using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mörkö : MonoBehaviour {

    public SpringControl spring;

    public int healthEnemy;

    public float moveSpeed;
    public bool hasReachedFirstTarget;
    public bool gameOver;

    private Transform target;
    private Transform target2;

    void Start()
    {
        healthEnemy = 10;
        hasReachedFirstTarget = false;
        gameOver = false;
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
        target2 = GameObject.FindGameObjectWithTag("Target2").GetComponent<Transform>();
    }

    void Update()
    {
        //Move towards first target
        if (!hasReachedFirstTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }

        //Check if has same position as "FirstTarget"
        if (transform.position == GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>().transform.position)
        {
            hasReachedFirstTarget = true;
        }

        //Move towards second target
        if (hasReachedFirstTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2.position, moveSpeed * Time.deltaTime);
        }

        //Check if has same position as "FinalTarget"
        if (transform.position == GameObject.FindGameObjectWithTag("Target2").GetComponent<Transform>().transform.position)
        {
            moveSpeed = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Hattiwatti" && spring.hasShot)
        {
            healthEnemy--;
        }
    }
}
