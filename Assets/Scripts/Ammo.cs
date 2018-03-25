using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    public float timeToJumpApex = .4f;

    public float gravity;
    public float jumpVelocity;

    void Start()
    {
        gravity = -(2 * 50) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    private void Update()
    {
        
    }
}
