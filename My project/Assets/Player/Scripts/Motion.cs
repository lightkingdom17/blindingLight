using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{

    public float velocity = 5f;
    public GameObject player;
    public Transform target;
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movmentCalc();
        rotationCalc();
    }
    //moves the character in acordance to the key inputs
    void movmentCalc(){

        //gets key inputs via predefined function
        float hori = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        //finds the location
        Vector3 direction = new Vector3(hori, 0, vert);
        
        controller.Move(direction * velocity * Time.deltaTime);
    }

    void rotationCalc(){
        //finds the diference between the 
        Vector3 relativePos = Input.mousePosition - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;
    }
}