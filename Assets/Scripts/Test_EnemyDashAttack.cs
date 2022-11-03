using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �÷��̾ ã��
// ������ ���� 2~3�� ����
// ������ ������ ������ ���� ���� ���¢��

public class Test_EnemyDashAttack : MonoBehaviour
{
    GameObject player;
    int rand;
    float speed = 20f;
    Vector3 dir;
    bool isFind;
    int count;
    float currentTime;
    float dashTime;
    float delayTime;
    BoxCollider meleeArea;

    // Start is called before the first frame upda te
    void Start()
    {
        player = GameObject.Find("Player");
        rand = Random.Range(2, 4);
        isFind = true;
        count = 0;
        dashTime = 2.0f;
        delayTime = 3.0f;
        currentTime = 0f;
        meleeArea = GetComponentInChildren<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (isFind == true)
        {
            dir = player.transform.position - transform.position;
            dir.Normalize();
            dir.y = 0;
            transform.LookAt(player.transform);
            count++;
            isFind = false;
        }


        if (count <= rand)
        {
            if (currentTime < dashTime)
            {
                transform.position += dir * speed * Time.deltaTime;
                // �������� Ȱ��ȭ
                
            }
            else if (currentTime > delayTime)
            {
                currentTime = 0;
                isFind = true;
            }
            
            
        }
        // ���� �ð�? �Ÿ�?
        
    }
}
