
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 4f;
    public float jumpForce = 7f;
    public Vector3 forward, right;
    public Rigidbody rigidBody;
    public bool isOnGround = true;
    public int limitedJumps;
    public int score =0;
    public int scoreGoal = 500;
    public int min =0;
    public int sec =0;
    float time;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        limitedJumps = 3;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        min = Mathf.RoundToInt(time / 60);
        sec = Mathf.RoundToInt(time % 60);
        if (Input.anyKey)
        {
            Move();
        }
        if(score >= scoreGoal)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    
    }

    void Move()
    {
        //src for moving the character
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;

        //src for making the character jump
        if ( Input.GetButtonDown("Jump") && isOnGround && limitedJumps != 0)
        {
            isOnGround = false;
            limitedJumps = limitedJumps -1;
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Terrain")
        {
            isOnGround = true;
        }
    }

    public int getLimitedJump()
    {
        return limitedJumps;
    }

    public void setScore(int newScore) => score = newScore;

    public void setSec(int newSec) => sec = newSec;

    public void setMin(int newMin) => min = newMin;

}
