using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float points;
    [SerializeField]
    float acceleration;
    [SerializeField]
    float MaxSpeed;
    private float lifeTime;
    public bool canEat;
    public Vector3 startVeclocity;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        lifeTime = 15.0f;
    }
    

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    protected void Movement()
    {
        if(rb.velocity.magnitude<MaxSpeed)
        {
            rb.velocity *=1+ (acceleration*Time.deltaTime);
        }
        lifeTime -= Time.deltaTime;
        if(lifeTime<=0)
        {
            Destroy(gameObject);
        }
    }
    public void Consumed()
    {
        //update score
        Destroy(this.gameObject);
    }
}
