using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float maxSpeed;
    public float maxZ;
    public float minZ;
    public float maxY;
    public float minY;
    public float MaxSickTime;
    private float sickTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sickTime<0)
        Movement();
        else
        {
            sickTime -= Time.deltaTime;
            if(sickTime<0)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
        ScreenLimits();
        
    }

    private void Movement()
    {
        //this controls the sharks movement and rotation
        rb.velocity+= new Vector3 (0, Input.GetAxis("Vertical")*15*Time.deltaTime, Input.GetAxis("Horizontal")*15 * Time.deltaTime);
        if(rb.velocity.z>maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
        }
        else if(rb.velocity.z<-maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxSpeed);
        }
        if (rb.velocity.y > maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, maxSpeed, rb.velocity.z);
        }
        else if (rb.velocity.y < -maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, -maxSpeed, rb.velocity.z);
        }


        if (rb.velocity.z>-0.01f)
        {
            transform.rotation = new Quaternion(0, 0, transform.rotation.z, 0); 
        }
        else if (rb.velocity.z < 0.01f)
        {
            transform.rotation = new Quaternion(0, 180, transform.rotation.z, 0);
        }
        
        rb.velocity = rb.velocity / (1+0.50f*Time.deltaTime);
    }

    private void ScreenLimits()
    {
        if (gameObject.transform.position.z >= maxZ)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxSpeed);
        }
        else if (gameObject.transform.position.z <= minZ)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeed);
        }

        if (gameObject.transform.position.y >= maxY)
        {
            rb.velocity = new Vector3(rb.velocity.x, -maxSpeed, rb.velocity.z);
        }
        else if (gameObject.transform.position.y <= minY)
        {
            rb.velocity = new Vector3(rb.velocity.x, maxSpeed, rb.velocity.z);
        }



    }
    public void Sickness()
    {
        transform.rotation = new Quaternion(0, 0, 180, 0);
        rb.velocity = new Vector3(0,-1,0);
        sickTime = MaxSickTime;
    }
   
}
