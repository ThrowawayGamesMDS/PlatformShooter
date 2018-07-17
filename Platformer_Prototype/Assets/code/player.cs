using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject[] platform;
    float speed = 10;
    public bool jump = true;
    public bool doubleJ = true;
    //public string platform;
    public Rigidbody Rid;
    public Vector3 ExtraVel;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            var move = new Vector3(0, 0, 1);
            transform.position += move * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            var move = new Vector3(0, 0, -1);
            transform.position += move * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            var move = new Vector3(-1, 0, 0);
            transform.position += move * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            var move = new Vector3(1, 0, 0);
            transform.position += move * speed * Time.deltaTime;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jump == true)
            {
                jump = false;
                Rid.AddForce(0, 500, 0, ForceMode.Impulse);
               // print("jump");
            }
            else
            {
                if (doubleJ == true)
                {
                    doubleJ = false;
                    Rid.velocity = Vector3.zero;
                    Rid.AddForce(0, 250, 0, ForceMode.Impulse);
                    //print("doublejump");
                }
            }
            
        }
       //print(ExtraVel);
        //transform.position = ExtraVel;
    }
    //void OnCollisionEnter(Collision Col)
    //{
    //    if (Col.gameObject.tag == "playforms")
    //    {
    //        int temp = -100;
    //        for (int i = 0; i < platform.Length; i++)
    //        {
    //            //print(platform[i].name);
    //            //print(Col.gameObject.name);
    //            if (Col.gameObject.name == platform[i].name)
    //            {
    //                //print("hope");
    //                temp = i;
    //            }
                
    //        }
    //        switch (temp)
    //        {
    //            case 0:
    //                print("0");
    //                break;
    //            case 1:
    //                print("1");
    //                break;

    //            case 2:
    //                print("2");
    //                break;

    //            case 3:
    //                print("3");
    //                break;

    //            case 4:
    //                print("4");
    //                break;

    //            case 5:
    //                print("5");
    //                break;

    //            case 6:
    //                print("6");
    //                break;
    //            default:
    //                break;
    //        }
        
    //    }
    //}
}
