using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tes : MonoBehaviour
{

    private Rigidbody my;
    // Start is called before the first frame update
    void Start()
    {
        my = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.my.velocity = new Vector3(0,0,16);

    }
}
