using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTheBall : MonoBehaviour
{
    public Transform BallPrefab;
    public int BallCount = 150;
    public float LeftLine = -10.0f;
    public float RightLine = 10.0f;
    public float ShotZ = -5.0f;
    public float ShotHeight = 0.5f;
    public float ShotAngleStart = 0.39f;
    public float ShotAngleEnd = 0.43f;
    public float ShotVerocity = 3.0f;
    public int FrameRate = 72;
    public int FixedUpdateRate = 72;
    public float TimeScale = 1.0f;

    private int frame = 0;
    
    // Start is called before the first frame update
    void Start()
    {   
        Time.timeScale = this.TimeScale;;
        Time.fixedDeltaTime = 1.0f / (float)this.FixedUpdateRate;        
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = this.FrameRate;       
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
