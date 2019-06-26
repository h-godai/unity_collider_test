using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Transform BeforeBallPrefab;
    public Transform CollisionBallPrefab;
    public Transform StayBallPrefab;
    public Transform ExitBallPrefab;

    private Rigidbody Rigidbody;
    private bool hasCollision = false;
    private void Awake()
    {
        this.Rigidbody = this.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (!this.hasCollision)
        {
            var obj = Instantiate(this.BeforeBallPrefab);
            obj.position = this.transform.position;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        var obj = Instantiate(this.CollisionBallPrefab);
        obj.transform.position = this.transform.position;
        this.hasCollision = true;
        if (this.transform.position.z > 0.0f && this.transform.position.y > 0.5f)
        {
            foreach (var c in collision.contacts)
            {
                Debug.DrawRay(c.point, c.normal, Color.red);
                Debug.Log($"OnCollisionEnter: {c.point} {c.normal} {c.separation}");
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        var obj = Instantiate(this.StayBallPrefab);
        obj.transform.position = this.transform.position;
        this.hasCollision = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        var obj = Instantiate(this.ExitBallPrefab);
        obj.transform.position = this.transform.position;
    }
}
