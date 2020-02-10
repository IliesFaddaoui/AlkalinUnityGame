using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Planet;

    public float pSpeed = 4.0f;
    public float jumpHeight = 1.2f;
    public float gravity = 9.1f;
    public bool onGround = false;
    private Rigidbody rigidbody;
    float distanceToGround;

    Vector3 Groundnormal;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Mov
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * pSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * pSpeed;
        transform.Translate(x, 0, z);
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(transform.up * 30000 * jumpHeight * Time.deltaTime);
        }

        //GroundControl
        RaycastHit hit = new RaycastHit();
        if(Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            distanceToGround = hit.distance;
            Groundnormal = hit.normal;

            if(distanceToGround <= 0.2f)
            {
                onGround = true;
            }
            else
            {
                onGround = false;
            }
        }

        //Gravity

        Vector3 gravityDirection = (transform.position - Planet.transform.position).normalized;

        if(onGround == false)
        {
            rigidbody.AddForce(gravityDirection * -gravity);
        }

        //

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, Groundnormal) * transform.rotation;
        transform.rotation = toRotation;
    }

    //Planet transition
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.transform != Planet.transform)
        {
            Planet = collider.transform.gameObject;
            Vector3 gravityDirection = (transform.position - Planet.transform.position).normalized;
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, gravityDirection) * transform.rotation;
            transform.rotation = toRotation;

            rigidbody.velocity = Vector3.zero;
            rigidbody.AddForce(gravityDirection * gravity);
        }
    }

    void Move()
    {

    }

    void Jump() {
    }
}
