using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JumpTextScript : MonoBehaviour
{

    public static int jumpVal;
    Text jumpLeft;
    // Start is called before the first frame update
    void Start()
    {
        jumpLeft = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        GameObject player = GameObject.Find("Cube");
        if(player != null)
        {
            CharController characterController = player.GetComponent<CharController>();
            jumpVal = characterController.getLimitedJump();
            if (jumpVal != 0)
            {
                jumpLeft.text = jumpVal + " Jumps left";
            }
            else
            {
                jumpLeft.text = "No more jump... :'(";
            }

        }

    }
}
