// File: ObjMovement.cs
// Author: Reddy-Priya-Pedhannavari
// Year: 2023
//
// Night Rider Project
// Copyright (c) 2023 RPriya234
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : MonoBehaviour
{
    private Animator anim, helmetAnim;

    public GameObject frontWheel, backWheel;
    //public GameObject road, building;
    public GameObject headlight;
    public GameObject bike,bike_rider , helmet;
    bool wheelrotation = false;
    int rotationTime = 1600;
    int Speed = 5;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        anim = bike_rider.gameObject.GetComponent<Animator>();
        helmetAnim = helmet.gameObject.GetComponent<Animator>();
        count = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)){
            wheelrotation = !wheelrotation;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            headlight.gameObject.GetComponent<SpriteRenderer>().enabled = !headlight.gameObject.GetComponent<SpriteRenderer>().enabled;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (count == 0)
            {
                anim.SetBool("getOffTheBike", true);
                anim.SetBool("hairFloatingAnimation", false);
                count = 1;
            }
            else
            {
                anim.SetBool("getOffTheBike", false);
                anim.SetBool("hairFloatingAnimation", true);
                count = 0;
            }
        }


        if (wheelrotation)
        {
            frontWheel.transform.Rotate(Vector3.forward * (rotationTime * Time.deltaTime));
            backWheel.transform.Rotate(Vector3.forward * (rotationTime * Time.deltaTime));
            bike.transform.Translate(Vector3.left * Speed * 3 * Time.deltaTime);
            //building.transform.Translate(Vector3.right * Speed * Time.deltaTime);
            //road.transform.Translate(Vector3.right * Speed*5 * Time.deltaTime);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "helmet collider")
        {
            helmetAnim.SetBool("helmetMove", true);
        }
    }
}
