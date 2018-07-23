using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightJoyStickDrag : MonoBehaviour
{

    //public float IOEdge;    //edge between inner and outer
    public Vector3 initPos;
    public Vector3 jsDir;
    //public bool dragInner;  // 1: drag inner  0: drag outer

    // Use this for initialization
    void Start()
    {
        initPos = GetComponent<RectTransform>().position;
        //dragInner = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    public void pointIO()
    {
        jsDir = Input.mousePosition - initPos;


        //judge drag inner or outer
        if (jsDir.magnitude > IOEdge)
        {
            //Debug.Log("outer");
            dragInner = false;
        }
        else
        {
            //Debug.Log("inner");
            dragInner = true;
        }
    }*/

    public void dragStart()
    {
        
    }

    public void dragEnd()
    {
        //dragInner = false;
        transform.position = initPos;
        jsDir = Vector3.zero;
    }
}
