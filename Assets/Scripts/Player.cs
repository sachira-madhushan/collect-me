using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject winPanel, lostPanel;
    private GameObject[] marks, redBall, health;
    int x, Len,y, ballCounter, index,conter2=0,healthCounter=2;
    bool lockMove=false;
  
    void Start()
    {
        health = GameObject.FindGameObjectsWithTag("health");
        marks = GameObject.FindGameObjectsWithTag("marks");
        redBall = GameObject.FindGameObjectsWithTag("win");
        ballCounter = redBall.Length;
        for (int x = marks.Length - 1; x >= 0; x--)
        {

            marks[x].SetActive(false);
        }
    }

    void Update()
    {
        

        Debug.Log("conter2" + conter2);
        Debug.Log("ballCounter" + ballCounter);
        if (healthCounter > -1)
        {
            if (Input.GetKey(KeyCode.F))
            {
                AttachRedBalls();
            }

            if (lockMove == false)
            {
                MoveForwardBackward();
                MoveRightLeft();
                LookAround();
            }

        }
        else if (conter2 <6)
        {
            LostPanelOpen();
        }
        
        if (conter2 == 6)
        {
            WinPanelOpen();
            lockMove = true;
        }







    }

    void MoveForwardBackward()
    {
        Vector3 move = Vector3.zero;
        move.z = Input.GetAxis("Vertical");
        transform.Translate(move*0.5f);
    }
    
    
    void MoveRightLeft()
    {
        Vector3 move = Vector3.zero;
        move.x = Input.GetAxis("Horizontal");
        transform.Translate(move * 0.5f);
    }
    
    
    void LookAround()
    {
        Vector3 move = Vector3.zero;
        move.y = Input.GetAxis("Mouse X");
        transform.Rotate(move );
    }

    
    
    void AttachRedBalls()
    {
        for(int x = ballCounter; x > 0; x--)
        {
            if(Vector3.Distance(redBall[x - 1].transform.position, transform.position) <= 20)
            {
                index = x-1;
            }
        }
        
        if (Vector3.Distance(redBall[index].transform.position,transform.position) <= 20&& redBall[index].gameObject.tag!="null")
        {
            
            marks[conter2].SetActive(true);
            marks[conter2].gameObject.tag = "null";
            redBall[index].SetActive(false);
            redBall[index].gameObject.tag = "null";


            conter2++;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(health[healthCounter]);
            Destroy(collision.gameObject);
            healthCounter--;
        }
    }

    void LostPanelOpen()
    {
        lostPanel.SetActive(true);
    }
    void WinPanelOpen()
    {
        winPanel.SetActive(true);
    }
}
