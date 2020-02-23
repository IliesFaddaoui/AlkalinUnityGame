using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowChar : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 10.0f;
    public float EPSILON = 0.1f;
    public NavMeshAgent meshAgent;
    public bool killCube = true;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Cube").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        meshAgent = this.GetComponent<NavMeshAgent>();
        if (meshAgent != null && target)
        {
            Vector3 destination = target.transform.position;
            meshAgent.SetDestination(destination);
        }
        /*
        * Old fashion way
         * if(GameObject.Find("Cube") != null)
        {
            target = GameObject.Find("Cube").transform;
            transform.LookAt(target.position);

            if ((transform.position - target.position).magnitude > EPSILON)
            {
                transform.Translate(0.0f, 0.0f, moveSpeed * Time.deltaTime);
            }
        }*/
        
}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube" && killCube)
        {
            Destroy(collision.gameObject);

        }
    }

}
