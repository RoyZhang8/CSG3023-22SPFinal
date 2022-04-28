/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Paddle controler on Horizontal Axis
****/

/*** Using Namespaces ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10; //speed of paddle
    private Rigidbody rb;


    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        float xAxis = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        transform.position = pos;
    }//end Update()
}
