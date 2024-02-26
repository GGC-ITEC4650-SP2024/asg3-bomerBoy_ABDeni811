using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkController : MonoBehaviour
{
    public GameObject exploPrefab;
    float speed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.down * Time.deltaTime * speed;
        if(transform.localPosition.y <= -1)
    {
        Destroy(transform.parent.parent.gameObject);
        Instantiate(exploPrefab, transform.position, transform.rotation);
    }
    }
}
