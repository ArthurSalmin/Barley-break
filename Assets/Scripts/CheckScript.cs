using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScript : MonoBehaviour
{
    public GameObject checkWin1;
    public GameObject checkWin2;
    public GameObject checkWin3;


    Ray[] rays;
    RaycastHit[] rayHits1;
    RaycastHit[] rayHits2;
    RaycastHit[] rayHits3;

    bool[] check;
    int check1 = 0;
    int check2 = 0;
    int check3 = 0;
    /// <summary>
    /// ////////////////
    /// </summary>
    // Use this for initialization
    void Start()
    {
        //check = new bool[3] { false, false, false };
        rays = new Ray[3];
        //rayHits1 = new RaycastHit[3];
        //rayHits2 = new RaycastHit[3];
        //rayHits3 = new RaycastHit[3];
        for (int i = 0; i < rays.Length; i++)
        {
            rays[i].direction = Vector3.right;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (checkWin1.transform.name == "1")
        {
            rays[0].origin = checkWin1.transform.position;
            rayHits1 = Physics.RaycastAll(rays[0], 1000f);
            for (int i = 0; i < rayHits1.Length; i++)
            {
                if (rayHits1[i].transform.name == (i + 1).ToString())
                {
                    check1++;
                }

            }
            //Debug.Log("ch1:" + check1);
        }

        if (checkWin2.transform.name == "2")
        {
            rays[1].origin = checkWin2.transform.position;
            rayHits2 = Physics.RaycastAll(rays[1], 1000f);

            for (int i = 0; i < rayHits2.Length; i++)
            {
                if (rayHits2[i].transform.name == (i + 4).ToString())
                {
                    check2++;
                }


            }
            //Debug.Log("ch2:" + check2);
        }



        if (checkWin3.transform.name == "3")
        {
            rays[2].origin = checkWin3.transform.position;
            rayHits3 = Physics.RaycastAll(rays[2], 1000f);
            for (int i = 0; i < rayHits3.Length; i++)
            {
                if (rayHits3[i].transform.name == (i + 7).ToString())
                {
                    check3++;
                }
            }
            //Debug.Log("ch3:" + check3);
        }

        Debug.Log("ch1:" + check1);
        Debug.Log("ch2:" + check2);
        Debug.Log("ch3:" + check3);
        if (check1 == 3 && check2 == 3 && check3 == 3)
        {
            Debug.Log("Win");
        }
        check1 = 0;
        check2 = 0;
        check3 = 0;
    }
}
