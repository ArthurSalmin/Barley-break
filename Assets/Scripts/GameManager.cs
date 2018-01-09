using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject[] numbers;

    private Ray[] mouseRay;
    private RaycastHit[] rayHit;

    private Ray mouseRay1;
    private RaycastHit rayHit1;
    void Start()
    {
        numbers = GameObject.FindGameObjectsWithTag("nums");
        BlendNumbers();

    }

    void BlendNumbers()
    {
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            int j = Random.Range(1, numbers.Length);
            int k = Random.Range(1, numbers.Length);
            Vector3 tempV = numbers[j].transform.position;
            numbers[j].transform.position = numbers[k].transform.position;
            numbers[k].transform.position = tempV;
        }
    }

    
    void CastRays()
    {
        mouseRay = new Ray[4];
        rayHit = new RaycastHit[4];
        for (int i = 0; i < mouseRay.Length; i++)
        {
            mouseRay[i].origin = rayHit1.transform.position;
        }
        mouseRay[0].direction = Vector2.up;
        mouseRay[1].direction = Vector2.down;
        mouseRay[2].direction = Vector2.right;
        mouseRay[3].direction = Vector2.left;

        //поменять на цикл из 4
        for (int i = 0; i < mouseRay.Length; i++)
        {
            if ((Physics.Raycast(mouseRay[i], out rayHit[i], 1000f)))
            {
                if (!rayHit[i].transform.GetComponent<numberScript>().status)
                {
                    Vector3 tempV = rayHit1.transform.position;
                    rayHit1.transform.position = rayHit[i].transform.position;
                    rayHit[i].transform.position = tempV;
                    break;
                }
                
            }
        }
        
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseRay1 = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay1, out rayHit1, 1000f))
            {
                if (rayHit1.transform.tag == "nums")
                {
                    CastRays();
                }
            }
        }
    }
}

//есть места где есть фишки, где нет - false, когда нажимают на объект в свободное место
//"короткие лучи"