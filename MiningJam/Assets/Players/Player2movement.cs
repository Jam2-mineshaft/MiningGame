using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2movement : MonoBehaviour
{
    private CharacterController controller;
    AudioSource asource;
    public GameObject Player1;
    public GameObject Player2;
    public int Speed;
    public int whatplayeristhis;

    void Start()
    {
        asource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(whatplayeristhis == 0)
        {
            MovementP1();
        }
        if(whatplayeristhis ==1)
        {
            MovementP2();
        }
      
       
    }
    void MovementP2()
    {
        Vector2 moveinput = new Vector2(Input.GetAxis("P2-leftjoyhori"), Input.GetAxis("P2-leftjoyverti"));
        Vector2 LookDir = new Vector2(Input.GetAxis("P2-rightjoyhori"), Input.GetAxis("P2-rightjoyverti"));
        



        Vector3 forward = transform.forward; //transform.forward;
        Vector3 right = transform.right; //transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 DesMoveDir = (forward * -moveinput.y + right * moveinput.x).normalized;
        Vector3 DesLookDir = (Vector3.right * LookDir.x + Vector3.forward * -LookDir.y).normalized;


        controller.Move(DesMoveDir * Speed * Time.deltaTime);
        if (DesLookDir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(DesLookDir.normalized), 0.15f);
        }
    }


    void MovementP1()
    {
        Vector2 moveinput = new Vector2(Input.GetAxis("P1-leftjoyhori"), Input.GetAxis("P1-leftjoyverti"));
        Vector2 LookDir = new Vector2(Input.GetAxis("P1-rightjoyhori"), Input.GetAxis("P1-rightjoyverti"));




        Vector3 forward = transform.forward; //transform.forward;
        Vector3 right = transform.right; //transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 DesMoveDir = (forward * -moveinput.y + right * moveinput.x).normalized;
        Vector3 DesLookDir = (Vector3.forward * -LookDir.y +Vector3.right * LookDir.x).normalized;
   

        controller.Move(DesMoveDir * Speed * Time.deltaTime);
        if (DesLookDir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(DesLookDir.normalized), 0.15f);
        }
    }
}
