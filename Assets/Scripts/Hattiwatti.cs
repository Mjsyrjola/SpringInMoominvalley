using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hattiwatti : MonoBehaviour
{
    public float moveSpeed;
    public bool hasReachedFirstTarget;
    public bool chargedUp;
    public int damage;

    private Transform target;
    private Transform target2;
    private Player player;

    void Start()
    {
        damage = 1;
        chargedUp = false;
        hasReachedFirstTarget = false;
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
        target2 = GameObject.FindGameObjectWithTag("Target2").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
        if (transform.position == GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().transform.position)
        {
            Destroy(gameObject);
        }

        ChargeUp();
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
    }

    public int CauseDamage()
    {
        if (chargedUp)
        {
            damage *= 2;
        }
        Debug.Log("Hit!");
        return damage;
    }

    public void ChargeUp()
    {
        if (transform.position == GameObject.FindGameObjectWithTag("Hattiwatti").GetComponent<Transform>().transform.position)
        {
            //Change color and do more damage
            chargedUp = true;
        }
    }
}
