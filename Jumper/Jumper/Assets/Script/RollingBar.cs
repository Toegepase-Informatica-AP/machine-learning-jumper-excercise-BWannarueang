using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBar : MonoBehaviour
{

    public float Speed;

    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = Vector3.right * Speed;
    }
}
