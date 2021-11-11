using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody Rb = null;
    private float MoveSpeed = 7;

    [SerializeField] 
    private Transform Cam = null;

    [SerializeField] 
    private Transform player = null;

    [SerializeField]
    private Transform MinimaSmall = null;

    private float StackTime = 0f;
    private float TimeValume = 60;
    float RemainTime = 0;

    private int SprayNum = 0;

    private Vector3 MoveDir = Vector3.zero;

    private Vector3 Playerforward = Vector3.zero;

    
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        StackTime += Time.deltaTime;
        RemainTime = TimeValume - StackTime;

        isMove();
            LookAt();

    }

    public float RemainTime_()
    {
        return RemainTime;
    }

    private void isMove()
    {

        float Z = Input.GetAxisRaw("Vertical");
        float X = Input.GetAxisRaw("Horizontal");
  
        Vector3 Lookforward = new Vector3(Cam.forward.x, 0f, Cam.forward.z).normalized;
        Vector3 LookRight = new Vector3(Cam.right.x, 0f, Cam.right.z).normalized;
        Vector3 MoveDir = Lookforward * Z + LookRight * X;

            player.transform.forward = Lookforward;
            this.transform.position += MoveDir * Time.deltaTime*MoveSpeed;
    }

    private void LookAt()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"),0);
        Vector3 CamAngle = Cam.rotation.eulerAngles;
        Cam.rotation = Quaternion.Euler(0, CamAngle.y + mouseDelta.x, 0).normalized;

        MinimaSmall.rotation = Quaternion.Euler(90, CamAngle.y + mouseDelta.x,0).normalized;

    }

    public void magnifier()
    {
        Vector3 UpPosition = new Vector3(0, 5, 0);
        MinimaSmall.position += UpPosition;
    }

    public void SpeedUp()
    {
        MoveSpeed += 1;
    }

    public void Spary()
    {
        SprayNum += 3;
    }

    public void TimeUp()
    {
        if(RemainTime+7 >= 60)
        {
            StackTime = 0;
        }
        else StackTime -= 7;

        Debug.Log("Á¦¹ß");
    }

 


  


}
