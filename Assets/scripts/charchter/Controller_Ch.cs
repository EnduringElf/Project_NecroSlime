using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller_Ch : MonoBehaviour
{
    public float movespeed = 5f;
    public float jumpHieght = 2.5f;
    private Rigidbody rb;

    public bool ISjumping = false;

    public KeyCode Jump_Key = KeyCode.Space;



    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement(){
        float moveX = Input.GetAxis("Horizontal") * movespeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * movespeed * Time.deltaTime;

        if(Input.GetKeyDown(Jump_Key) && !ISjumping)
        {
            rb.AddForce(Vector3.up * jumpHieght, ForceMode.Impulse);
            ISjumping = true;
            
            
        }else
        {
             Vector3 movement = new Vector3(moveX, 0, moveZ);
             rb.MovePosition(rb.position + movement);
        }
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "ground"){
            ISjumping = false;
        }
    }




    
}
