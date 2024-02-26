using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTosser : MonoBehaviour
{
    public GameObject[] bombPrefab;
    int currentBombIndex = 0;
    BombController bcon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject g = Instantiate(bombPrefab[currentBombIndex]);
            g.transform.parent = transform;
            g.transform.localPosition = Vector3.zero;
            g.transform.forward = transform.forward;
            bcon = g.GetComponent<BombController>();
        }
        else if (Input.GetMouseButtonUp(0) && bcon != null)
        {
            bcon.toss();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            currentBombIndex = (currentBombIndex + 1) % bombPrefab.Length;
        }

    }
}
