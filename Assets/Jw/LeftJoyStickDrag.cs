using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftJoyStickDrag : MonoBehaviour
{

    public Vector3 initPos;
    public float r;
    public Vector3 jsDir;    //the direction which joystick is dragged to


    // Use this for initialization
    void Start()
    {
        initPos = GetComponent<RectTransform>().position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void dragStart()
    {
        //Debug.Log("dragStart");
        jsDir = Input.mousePosition - initPos;

        //dragged distance < r
        if (jsDir.magnitude < r)
        {
            transform.position = initPos + jsDir;
        }

        //dragged distance > r
        else
        {
            transform.position = initPos + jsDir.normalized * r;
        }
    }

    public void dragEnd()
    {
        //Debug.Log("dragEnd");
        jsDir = Vector3.zero;

        transform.position = initPos;
    }
}

