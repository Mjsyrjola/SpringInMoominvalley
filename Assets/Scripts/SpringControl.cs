using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringControl : MonoBehaviour {

    public GameObject pointer;
    public GameObject ammo;
    Rigidbody rb_ammo;
    public Transform shotPos;
    public float firePower;
    public int powerMultiplier = 1;

    public Player player;
    public Animator anim;

    public float powerBarMax;
    public float powerBarCurrent;
    public bool hasShot;
    bool isLoading;
    public int ammoPile;
    public bool ammoReady;

    void Start () {
        ammoReady = false;
        ammoPile = 5;
        isLoading = false;
        powerBarMax = 5000;
        powerBarCurrent = powerBarMax;
        anim = GetComponent<Animator>();
    }

	void Update () {
        InstantiateAmmo();
        LoadSpring();
        if (Input.GetKeyUp(KeyCode.S) && isLoading || powerBarCurrent == 0)
        {
            Shoot();
        }

    }

    void InstantiateAmmo()
    {
        if (Input.GetMouseButtonDown(0) && player.count >= 5 && !ammoReady)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 50000000, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Hat")
                {
                    ammoReady = true;
                    player.count -= 5;
                }
            }
        }
    }

    void LoadSpring()
    {
        if (Input.GetKey(KeyCode.S) && ammoReady)
        {
            powerBarCurrent--;
            if (powerBarCurrent <= 0)
            {
                powerBarCurrent = 0;
            }
            isLoading = true;
            anim.Play("spring_load");
        }
    }

    void Shoot()
    {
        firePower = powerBarMax - powerBarCurrent;
        ammoReady = false;
        shotPos.rotation = transform.rotation;
        firePower *= powerMultiplier;
        GameObject ammoCopy = Instantiate(ammo, shotPos.position, transform.rotation) as GameObject;
        rb_ammo = ammoCopy.GetComponent<Rigidbody>();
        //rb_ammo.AddForce(transform.up * firePower);
        //rb_ammo.AddForce(-transform.forward * firePower);
        rb_ammo.AddForce(0, 0, pointer.transform.rotation.z * firePower);
        anim.Play("spring_shoot");
        powerBarCurrent = powerBarMax;
        isLoading = false;
        ammoReady = false;
    }
}
