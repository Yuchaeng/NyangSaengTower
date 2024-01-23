using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public GameObject StairPrefab;

    public float maxX = 3.2f;
    public float minX = -3.2f;

    public float offsetX = 1.6f;
    public float offsetY = 0.7f;

    decimal calOriginX;
    decimal calAddX;
    decimal calOriginY;
    decimal calAddY;
    float resultX;
    float resultY;

    public GameObject originStair;
    public Vector3 previousStair;
    public Vector3 newStair;

    public Vector3[] positons = new Vector3[50];

    private void Start()
    {
        //�̰ź����� ������
        //originStair = GetComponent<GameObject>();
        //StairPrefab = GetComponent<GameObject>();


        previousStair = originStair.transform.position;      

        for (int i = 0; i < 150; i++)
        {
            calOriginX = (decimal)previousStair.x;
            calOriginY = (decimal)previousStair.y;
            calAddX = (decimal)offsetX;
            calAddY = (decimal)offsetY;

            int direction;

            // ���� ������ ���� �� ���� ���� ��
            if(previousStair.x == minX)
            {
                direction = 1;
            }
            // ���� ������ ������ �� ���� ���� ��
            else if (previousStair.x == maxX)
            {
                direction = 0;
            }
            else
            {
                direction = UnityEngine.Random.Range(0, 2);  // 0 �Ǵ� 1 ���� �� -> 0�� ���� 1�� ������
            }


            //���⿡ ���� ���� ���� ��ġ ����
            if (direction == 0)
            {
                resultX = (float)(calOriginX - calAddX);
                resultY = (float)(calOriginY + calAddY);

                newStair = new Vector3(resultX, resultY, 0);
            }
            else if (direction == 1)
            {
                resultX = (float)(calOriginX + calAddX);
                resultY = (float)(calOriginY + calAddY);

                newStair = new Vector3(resultX, resultY, 0);
            }

            positons[i] = newStair;
            Instantiate(StairPrefab, newStair, Quaternion.Euler(0, 0, 0));

            previousStair = newStair;
            newStair = Vector3.zero;
        }
    }
}
