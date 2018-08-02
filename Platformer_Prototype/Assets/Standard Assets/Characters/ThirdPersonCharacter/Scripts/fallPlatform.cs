using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class fallPlatform : MonoBehaviour
    {
        public bool Falling = false;
        public float time = 60;
        public float Dtime = 300;
        public GameObject death;
        Vector3 deathcor;
       // Use this for initialization
       void Start()
        {
            deathcor = (transform.position);
        }

        // Update is called once per frame
        void Update()
        {
            if (Falling == true)
            {
                if (time == 0)
                {
                    var move = new Vector3(0, -1, 0);
                    if (Dtime == 0)
                    {
                      
                        Destroy(gameObject); 
                    }
                   
                    transform.position += move * 2.5f * Time.deltaTime;
                    Dtime--;
                }
                else
                {
                    time--;
                }
            }
            //if (Input.GetKeyDown(KeyCode.C))
            //{
            //    Falling = true;
            //}
        }
        public void playerON()
        {
            GameObject die = Instantiate(death, deathcor, Quaternion.identity);
            //print("falling");
            Falling = true;
         
        }
    }
}
