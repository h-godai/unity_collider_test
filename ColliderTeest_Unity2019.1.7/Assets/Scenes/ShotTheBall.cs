using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTheBall : MonoBehaviour
{
    public Transform BallPrefab;
    public int BallCount = 30;
    public float LeftLine = -5.0f;
    public float RightLine = 5.0f;
    public float ShotZ = -10.0f;
    public float ShotHeight = 1.0f;
    public float ShotAngleStart = 0.0f;
    public float ShotAngleEnd = 30.0f;
    public float ShotVerocity = 40.0f;
    private int frame = 0;
    
    // Start is called before the first frame update
    void Start()
    {   
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 1.0f / 72.0f;        
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 72;       
    }

    // Update is called once per frame
    void Update()
    {
        if (this.frame < this.BallCount)
        {
            var progress = (float)this.frame / (float)this.BallCount;
            var x = this.LeftLine + progress * (this.RightLine - this.LeftLine);
            var vy = this.ShotAngleStart + progress * (this.ShotAngleEnd - this.ShotAngleStart);
            var ball = Instantiate(this.BallPrefab);
            ball.position = new Vector3(x, this.ShotHeight, this.ShotZ);
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, vy, this.ShotVerocity), ForceMode.Impulse);
        }
        ++this.frame;
    }
}
