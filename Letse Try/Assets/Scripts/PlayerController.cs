using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float walkSpeed = 10;
    public float runSpeed = 20;
    bool locked;
	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        locked = true;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;
        bool running = Input.GetKey(KeyCode.LeftShift);
        float speed = ((running) ? runSpeed : walkSpeed * inputDir.magnitude);

        //+++++++++++++++++++++++++++++

        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"));
        {
            locked = !locked;
            if (locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        //+++++++++++++++++++++++++++++
       /*  if(inputDir != Vector2.zero) { 
         transform.eulerAngles = Vector3.up * Mathf.Atan2(inputDir.x, inputDir.y)*Mathf.Rad2Deg;
         }
        **/ 
        

        //transform.Translate(transform.position * speed * Time.deltaTime, Space.World);
    }
}
