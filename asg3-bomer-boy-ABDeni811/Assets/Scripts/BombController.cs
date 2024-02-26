using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public Vector3 tossVel;
    Collider myCol;
    // Start is called before the first frame update
    void Start()
    {
        myCol = GetComponent<Collider>();
        //toss();
    }

    // Update is called once per frame
    public void toss()
    {
        transform.parent = null;
        //myCol.enabled = false;
        Rigidbody r = gameObject.AddComponent<Rigidbody>();
        r.constraints = RigidbodyConstraints.FreezeRotation;
        r.velocity = tossVel.z * transform.forward + tossVel.y * Vector3.up;
        Invoke("enableCol", 0.1f);
    }
    void enableCol()
    {
        myCol.enabled = true;
    }
}
