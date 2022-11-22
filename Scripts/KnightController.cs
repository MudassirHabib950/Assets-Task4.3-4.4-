using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnightController : MonoBehaviour
  {
   public float speed = 4.0f;
   public float rotationSpeed = 80f;
   public float rot = 0f;
   public float gravity = 8.0f;
    Vector3 movDir = Vector3.zero;
    public CharacterController controller;
    public Animator anim;
    void Start()
    {
    controller = GetComponent<CharacterController>();
    anim = GetComponent<Animator>();
    }
     void Update()
     {
      Movement();
      GetInput();
    }
      void Movement()
      {
         if(controller.isGrounded)
      {
       if(Input.GetKey(KeyCode.W))
       {
        if(anim.GetBool("attacking") == true)
        {
            return;
        }
        else if(anim.GetBool("attacking") == false)
        {
       anim.SetBool ("running",true);
       anim.SetInteger ("condition",1);
       movDir = new Vector3(0,0,10);
       movDir *= speed;
       movDir = transform.TransformDirection(movDir);
        }
       }
       if(Input.GetKeyUp(KeyCode.W))
       {
        anim.SetBool ("running",false);
        anim.SetInteger ("condition",0);
        movDir = new Vector3(0,0,0);
       }
      }
       rot += Input.GetAxis("Horizontal")  * rotationSpeed * Time.deltaTime;
       transform.eulerAngles = new Vector3 (0,rot,0);
       movDir.y -= gravity * Time.deltaTime;
       controller.Move(movDir * Time.deltaTime);


      }
      void GetInput()
      {
      if(controller.isGrounded)
      {
       if(Input.GetMouseButton(0))
       if(anim.GetBool("running") == true)
       {
        anim.SetBool("running",false);
        anim.SetInteger("condition",0);
       }
       if(anim.GetBool("running")== false)
       {
         Attacking();
       }
       
      }

      }
      void Attacking()
      {
    
      StartCoroutine(AttackRoutine());
    
      IEnumerator AttackRoutine()
      {
      anim.SetBool("attacking",true);
      anim.SetInteger("condition",2);
      yield return new WaitForSeconds(1);
      anim.SetInteger("condition",0);
      anim.SetBool("attacking",true);
      }
      }
}
