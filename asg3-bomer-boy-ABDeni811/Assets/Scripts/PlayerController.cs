using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Text gameOver;
    Text timeTxt;
    float health = 100;
    Rigidbody myBod;
    public float speed;
    public float timeChg;
    Vector3 myRot;
    Transform greenTran;


    void Start()
    {
        myBod = GetComponent<Rigidbody>();
        greenTran = GameObject.Find("GreenHealth").transform;

        gameOver = GameObject.Find("Gover").GetComponent<Text>();

        //damage(45);
        timeTxt = GameObject.Find("Timer").GetComponent<Text>();
        gameOver.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        timeChg += Time.deltaTime / 2;

        timeTxt.text = "Timer: " + (int)timeChg;

        if (transform.position.y <= 1.1f)
        {
            //on ground
            //make the ball move
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 f = transform.right * h + transform.forward * v;
            f.y = 0;
            myBod.AddForce(f * Time.deltaTime * speed);

            //jump
            if (Input.GetButtonDown("Jump"))
            {
                myBod.AddForce(Vector3.up * 6, ForceMode.Impulse);
            }
        }
        //flying
        else
        {
            myBod.drag = 0;
        }

        //camera movement
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        Vector3 rotStep = x * Vector3.up + -y * Vector3.right;
        myRot += rotStep * Time.deltaTime * speed;
        //Vector3 s = Vector3.right * y + Vector3.up * x;
        //myRot += (s * Time.deltaTime * 360);

        if (myRot.x > 30)

            myRot.x = 30;

        if (myRot.x < -30)

            myRot.x = -30;

        transform.eulerAngles = myRot;

    }
    public void damage(float d)
    {
        health -= d;
        if (health <= 0)
        {
            //dead
            Time.timeScale = 0;
            gameOver.text = "Game Over";

        }
        greenTran.localScale = new Vector3(health / 100, 1, 1);
    }
}

