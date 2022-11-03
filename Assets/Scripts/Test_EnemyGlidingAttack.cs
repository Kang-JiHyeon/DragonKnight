using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 3�� ������ ��������.
// ������ġ - ������ġ 2�� ���� ������ ����

// ���� �����鼭 �������� �ٴڿ� ���� �������� ������.

// ���Ŀ��� �ϰ��������� ����


public class Test_EnemyGlidingAttack : MonoBehaviour
{
    GameObject target;
    Vector3 startpos1;
    Vector3 startpos2;
    Vector3 arrivepos1;
    Vector3 arrivepos2;
    int rand;
    public GameObject fireFactory;
    float currentTime = 0;
    bool isarrive = true;
    int count = 0;
    float delayTime = 3.0f;
    Vector3 targetpos;
    float speed = 30f;
    GameObject mouth;
    GameObject fire;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        rand = Random.Range(0, 2);
        startpos1 = new Vector3(0, 20, 50);
        arrivepos1 = new Vector3(0, 20, -50);
        startpos2 = new Vector3(-50, 20, 0);
        arrivepos2 = new Vector3(50, 20, 0);
        mouth = GameObject.Find("Mouth");

        

    }

    // Update is called once per frame
    void Update()
    {
        // ������ġ�� �ƴ϶�� ������ġ�� �̵�
        if (isarrive == true)
        {
            if (transform.position.z >= 49.5f || transform.position.x <= -49.5f)
            {
                isarrive = false;
            }
            else
            {
                if (rand == 0)
                {
                    transform.position = Vector3.Lerp(transform.position, startpos1, 0.01f);
                    transform.LookAt(target.transform.position);
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, startpos2, 0.01f);
                    transform.LookAt(target.transform.position);
                }
            }
        }
        else
        {
            currentTime += Time.deltaTime;

            if (count < 3)
            {


                if (count == 0)
                {
                    
                    fire = Instantiate(fireFactory);
                    fire.transform.position = mouth.transform.position;
                    

                    if (currentTime <= delayTime)
                    {
                        if (rand == 0)
                        {
                            transform.position = Vector3.Lerp(transform.position, arrivepos1, 0.005f);
                        }
                        else
                        {
                            transform.position = Vector3.Lerp(transform.position, arrivepos2, 0.005f);
                        }
                    }
                    else
                    {
                        transform.LookAt(target.transform.position);
                        currentTime = 0f;
                        count++;
                        targetpos = target.transform.position - transform.position;
                        targetpos.Normalize();
                        targetpos.y = 0;

                    }
                }
                else if(count > 0 )
                {
                    if (currentTime <= delayTime)
                    {
                        transform.position += targetpos * speed * Time.deltaTime;
                        fire = Instantiate(fireFactory);
                        fire.transform.position = mouth.transform.position;

                    }
                    else
                    {
                        transform.LookAt(target.transform.position);
                        currentTime = 0f;
                        count++;
                        targetpos = target.transform.position - transform.position;
                        targetpos.Normalize();
                        targetpos.y = 0;
                    }
                }

            }
        }
    }
}
