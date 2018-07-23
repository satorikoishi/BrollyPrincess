using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject character;
    public GameObject umbrella;
    public float maxLen;            //long length
    public float minLen;            //short length
    public bool opened;             //state of umbrella: opened
    public bool stred;              //state of umbrella: stretched
    public Vector3 defaultDir;      //direction of umbrella when walking
    public Vector3 umDirection;     //direction of umbrella when opened/stretched

    public float groundHeight;      
    public Vector3 chaForce;        //force on character
    public Vector3 umForce;         //force on umbrella
    public Vector3 gravity;         //gravity

    private float distance;         //distance between character and umbrella(max or min)
    private Vector3 chaSpeed;       //character speed
    private Vector3 umSpeed;        //umbrella speed
    public Vector3 XunitSpeed;      //unit speed on Xaxis
    public Vector3 YunitSpeed;      //unit speed on Yaxis

    // Use this for initialization
    void Start()
    {
        distance = minLen;

        chaSpeed = XunitSpeed * 10f;

        umSpeed = chaSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        //WASD to move character / JKLI to move umbrella
        if (Input.GetKeyDown(KeyCode.A))
        {
            chaSpeed -= XunitSpeed;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            chaSpeed += XunitSpeed;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            chaSpeed += YunitSpeed;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            chaSpeed -= YunitSpeed;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            umSpeed -= XunitSpeed;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            umSpeed += XunitSpeed;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            umSpeed += YunitSpeed;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            umSpeed -= YunitSpeed;
        }

        //open umbrella
        if (Input.GetKeyDown(KeyCode.Q))
        {
            opened = !opened;
        }
        //stretch umbrella
        if (Input.GetKeyDown(KeyCode.E))
        {
            stred = !stred;
        }

        //default state
        if (!stred && !opened)
        {
            umbrella.transform.position = character.transform.position + defaultDir * distance;

        }

        if (!stred)
        {
            umSpeed = chaSpeed;
        }

        if (stred)
        {
            distance = maxLen;
        }
        else
        {
            distance = minLen;
        }

        //first calculate umbrella pos and attach character to it
        if (opened && stred)
        {
            FCalcUm();
            CalcCha();
        }
        //firsr calculate character pos and attach umbrella to it
        else
        {
            FCalcCha();
            CalcUm();
        }

        //Debug.Log("chaSpeed: " + chaSpeed);
        //Debug.Log("umSpeed " + umSpeed);

    }

    void CalcUm()
    {
        
        //according to umDirection and distance, decide umbrella pos
        if (!(Mathf.Abs(umDirection.magnitude - 1) < 0.00001) && !(Mathf.Abs(umDirection.magnitude - 0) < 0.00001))
        {
            umDirection.Normalize();
        }

        umbrella.transform.position = character.transform.position + umDirection * distance;
        umSpeed = chaSpeed;

    }

    void FCalcUm()
    {
        //umSpeed+=G until hits ground

        //umSpeed += umForce;

        if (umbrella.transform.position.y > groundHeight)
        {
            umSpeed += gravity / 4f;

        }
        else if (umSpeed.y < 0)
        {
            umSpeed = new Vector3(umSpeed.x, 0, 0);
        }

        umbrella.transform.position += umSpeed * Time.deltaTime;

        //umSpeed -= umForce;



    }

    void CalcCha()
    {
        //update Vector3 between um and cha, then calc direction, then calc pos
        //seems has forgotten to update character speed

        /*
        Vector3 chaDirection = Vector3.zero;
        Vector3 newChaPos = Vector3.zero;
        newChaPos = character.transform.position;
        newChaPos += chaSpeed + gravity;
        Debug.Log("1 " + chaSpeed);
        chaDirection = (newChaPos - umbrella.transform.position).normalized;
        //Debug.Log(chaDirection);
        character.transform.position = umbrella.transform.position + chaDirection * distance;
        Debug.Log("2 " + chaSpeed);
        */

        Vector3 chaDirection = Vector3.zero;
        Vector3 newChaPos = Vector3.zero;
        newChaPos = character.transform.position;
        //chaSpeed += gravity;
        newChaPos += chaSpeed + gravity;
        //Debug.Log("1 " + chaSpeed);
        chaDirection = (newChaPos - umbrella.transform.position).normalized;
        //Debug.Log(chaDirection);
        character.transform.position = umbrella.transform.position + chaDirection * distance;
        //Debug.Log("2 " + chaSpeed);

    }

    void FCalcCha()
    {
        //almost same as FCalcUm, except for the last func


        //chaSpeed += chaForce;

        if (character.transform.position.y > groundHeight)
        {
            chaSpeed += gravity;
        }
        else if (chaSpeed.y < 0)
        {
            chaSpeed = new Vector3(chaSpeed.x, 0, 0);
        }

        character.transform.position += chaSpeed * Time.deltaTime;

        //chaSpeed -= chaForce;

        //set umDirection negative to umSpeed(maybe need to change)
        if (!(Mathf.Abs(umForce.magnitude - 0) < 0.00001))
        {
            umDirection = -umSpeed.normalized;
        }

    }

}
