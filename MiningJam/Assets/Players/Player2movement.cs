using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2movement : MonoBehaviour
{

    private Rigidbody rB;
    public GameObject Player1;
    public GameObject Player2;
    private Transform Camtransform;

    public int Speed;
    public int whatplayeristhis;

    float hori1;
    float verti1;
    float hori2;
    float verti2;

    void Start()
    {
        Camtransform = Camera.main.transform;
        rB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        hori1 = Input.GetAxis("P1-leftjoyhori");
        verti1 = Input.GetAxis("P1-leftjoyverti");

        hori2 = Input.GetAxis("P2-leftjoyhori");
        verti2 = Input.GetAxis("P2-leftjoyverti"); 
    }
    void FixedUpdate()
    {
        if (whatplayeristhis == 0)
        {
            MovementP1();
        }
        if (whatplayeristhis == 1)
        {
            MovementP2();
        }
    }
    void MovementP2()
    {            
        Vector2 LookDir = new Vector2(Input.GetAxis("P2-rightjoyhori"), Input.GetAxis("P2-rightjoyverti"));
        

        Vector3 forward = Camtransform.forward; //transform.forward;
        Vector3 right = Camtransform.right; //transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 DesMoveDir2 = (forward * -verti2 + right * hori2).normalized;
        
        Vector3 DesLookDir = (Vector3.right * LookDir.x + Vector3.forward * -LookDir.y).normalized;

        rB.velocity = DesMoveDir2 * Speed;

        if (DesLookDir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(DesLookDir.normalized), 0.15f);
        }
    }


    void MovementP1()
    {
       
        Vector2 LookDir = new Vector2(Input.GetAxis("P1-rightjoyhori"), Input.GetAxis("P1-rightjoyverti"));


        Vector3 forward = Camtransform.forward; //transform.forward;
        Vector3 right = Camtransform.right; //transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 DesMoveDir = (forward * -verti1 + right * hori1).normalized;

        Vector3 DesLookDir = (Vector3.forward * -LookDir.y +Vector3.right * LookDir.x).normalized;

        rB.velocity = DesMoveDir * Speed;

        if (DesLookDir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(DesLookDir.normalized), 0.15f);
        }
    }
}
