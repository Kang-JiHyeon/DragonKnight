using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ι� ����

public class Test_EnemyBiteAttack : MonoBehaviour
{
    GameObject target;
    float currentTime = 0;
    bool isFind = true;
    float biteTime1 = 1.5f;
    float biteTime2 = 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (isFind == true)
        {
            transform.LookAt(target.transform);
            isFind = false;
        }

        if (currentTime < biteTime1)
        {
            // anim.SetTrigger("BiteAttack");
            print("����1");
            // �������� Ȱ��ȭ
        }
        else if (currentTime > biteTime1 && currentTime < 2.0f)
        {
            isFind = true;
        }
        else if (currentTime > biteTime1 && currentTime < biteTime2)
        {
            // anim. SetTrigger("BiteAttack2");
            print("����2");
        }
        else
        {
            // �������� ��Ȱ��ȭ
        }
    }
}