using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCoin : MonoBehaviour
{
    public GameObject coin;
    public float rotationSpeed = 50.0f;
    public float lifeTime = 10.0f;
    public float x = 90f;
    public float y = 0f;
    public float z = 0f;
    // Start is called before the first frame update
    void Start()
    {
        coin.transform.Rotate(new Vector3(90, 0, 0));
        //zcoin.transform.Rotate(x, y, z);
        rotationSpeed = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        coin.transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotationSpeed *10));
        if(lifeTime != 0)
        {
            Destroy(coin, lifeTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube" )
        {
            GameObject player = GameObject.Find("Cube");
            Destroy(coin);
            CharController characterController = player.GetComponent<CharController>();
            int score = characterController.score;
            characterController.setScore(score + 10);
        }
    }
}
