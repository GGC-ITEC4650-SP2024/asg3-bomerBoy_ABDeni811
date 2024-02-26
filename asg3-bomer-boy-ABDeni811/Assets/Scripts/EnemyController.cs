using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    //Text winTxt;
    public float speed;
    public float bombSpacing;
    public GameObject bombPrefab;
    //components
    Rigidbody myBod;
    NavMeshAgent myAgent;
    Transform playerTran;
  

    bool chasePlayer = true;
    Vector3 startPos;
    float bombTimer;
    void Start()
    {
        myBod = GetComponent<Rigidbody>();
        myAgent = GetComponent<NavMeshAgent>();
        playerTran = GameObject.Find("Player").transform;

        myAgent.isStopped = true;
        startPos = transform.position;
        bombTimer = bombSpacing;

       //winTxt = GameObject.Find("Win").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        bombTimer -= Time.deltaTime;
        if (chasePlayer)
        {
            myAgent.destination = playerTran.position;

        }
        else
        {
            myAgent.destination = startPos;
        }
        //movement
        Vector3 f = myAgent.steeringTarget - transform.position;
        f.y = 0;
        myBod.AddForce(f.normalized * Time.deltaTime * speed);

        //Roatation
        Vector3 v = playerTran.position - transform.position;
        v.y = 0;
        transform.forward = v;

        //whem to throw a bomb?
        if (!wallBlocked(playerTran.position) && chasePlayer && bombTimer <= 0)
        {
            bombTimer = bombSpacing;
            GameObject g = Instantiate(bombPrefab);
            g.transform.position = transform.position + transform.forward + Vector3.up;
            g.transform.forward = transform.forward;
            g.GetComponent<BombController>().toss();
            chasePlayer = false;
        }
        if (!chasePlayer && Vector3.Distance(transform.position, startPos) < 1)
        {
            chasePlayer = true;
        }
    }


    private bool wallBlocked(Vector3 targetPos)
    {
        RaycastHit hitInfo;
        if (Physics.Linecast(transform.position, targetPos, out hitInfo))
        {
            if (hitInfo.collider.tag == "Wall")
            {
                return true;
            }
        }
        return false;
    }
  
}
