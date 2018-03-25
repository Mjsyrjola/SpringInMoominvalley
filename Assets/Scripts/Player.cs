using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Text countText;

    public int healthCurrent;
    public int healthMax;

    public bool canMakeAmmo;

    public int count;

    void Start()
    {
        count = 5;

        healthMax = 10;
        healthCurrent = healthMax;

        canMakeAmmo = false;

        countText.text = "x = " + count.ToString();
    }

    void Update()
    {
        TakeDamage();
        CatchHattiwatti();
        countText.text = "x = " + count.ToString();
        if(count < 5)
        {
            canMakeAmmo = false;
        }
    }

    void TakeDamage()
    {
        if (transform.position == GameObject.FindGameObjectWithTag("Hattiwatti").GetComponent<Transform>().transform.position)
        {
            healthCurrent--;
        }
    }

    void Die()
    {
        if (healthCurrent <= 0)
        {
            healthCurrent = 0;
        }
    }

    void CatchHattiwatti()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 50000000, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Hattiwatti")
                {
                    count++;
                }
            }
        }
    }
}
