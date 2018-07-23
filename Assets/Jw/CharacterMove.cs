using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    public LeftJoyStickDrag leftJoyStick;
    public float speed;                //character moving speed
    public float lowThreshold;         //for dragging angle
    public float highThreshold;        //for dragging angle
    public float draggingThreshold;    //for dragging distance, if lower than it, consider as not dragging

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when pulled to a sufficient distance
        if (leftJoyStick.jsDir.magnitude > draggingThreshold)
        {

            //when x=0
            //dragged up
            if (Mathf.Abs(leftJoyStick.jsDir.x) < 0.0001)
            {
                CharacterJump();
                return;
            }

            //calc Atan(y/x)
            float rad = Mathf.Atan(leftJoyStick.jsDir.y / leftJoyStick.jsDir.x);
            //Debug.Log(rad);

            //abs(arctan<low)
            if (Mathf.Abs(rad) < lowThreshold)
            {
                //dragged to right
                if (leftJoyStick.jsDir.x > 0)
                {
                    CharacterMoveRight();
                }
                //dragged to left
                if (leftJoyStick.jsDir.x < 0)
                {
                    CharacterMoveLeft();
                }
            }

            //abs(arctan>high)
            //dragged up
            else if (Mathf.Abs(rad) > highThreshold && leftJoyStick.jsDir.y > 0)
            {
                CharacterJump();
            }
        }
    }

    void CharacterMoveLeft()
    {
        //To do

        transform.position -= new Vector3(speed, 0, 0);
        Debug.Log("left");
    }

    void CharacterMoveRight()
    {
        //To do

        transform.position += new Vector3(speed, 0, 0);
        Debug.Log("right");
    }

    void CharacterJump()
    {
        //To do

        transform.position += new Vector3(0, speed, 0);
        Debug.Log("jump");
    }
}