using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBalls : MonoBehaviour
{
    public GameObject Player;
    float MinDist = 50f, MaxDist = 20f, power = 200f;
    public float MoveSpeed = 50f;
    string returnValue;
    private Rigidbody rb;
    private GameObject[] marks;
    int x, Len, y;

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
