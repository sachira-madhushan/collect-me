using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public GameObject Player;
    float MinDist = 50f, MaxDist = 50f;
    public float MoveSpeed = 50f;
    private float power = 200f;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.LookAt(Player.transform);
        follome();


        if (Input.GetKey(KeyCode.R))
        {
            repel();
        }

    }





    void repel()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) <= MinDist)
        {



            
            transform.Translate(0, 0, -power * Time.deltaTime);


            if (Vector3.Distance(transform.position, Player.transform.position) >= MaxDist)
            {
          
            }
        }
    }

    void follome()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) <= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.transform.position) >= MaxDist)
            {
            }
        }
    }


}
