using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Transform BeforeBallPrefab;

    private Transform beforeBall;
    private Vector3 lastPosition = Vector3.zero;
    private void Awake()
    {
        this.beforeBall = Instantiate(this.BeforeBallPrefab);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<Rigidbody>().isKinematic && this.transform.position.z < 0.0f)
        {
            this.lastPosition = this.transform.position;
        }
        this.beforeBall.position = this.lastPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<Rigidbody>().isKinematic = true;
    }
}
