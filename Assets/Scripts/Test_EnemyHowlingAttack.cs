using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Ÿ��� ���� �ٸ��� ���� �����ϼ� ���� �Ѵ�.
// ��ǥ, �Ÿ�, ���� ��ũ��Ʈ ȣ��(����)

public class Test_EnemyHowlingAttack : MonoBehaviour
{
    GameObject target;
    GameObject mouth;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        mouth = GameObject.Find("Mouth");
        distance = Vector3.Distance(target.transform.position, mouth.transform.position);

        if (distance < 15)
        {
            // ���� �����ɸ���
            print("���� ����");
        }
        else if (distance < 30)
        {
            // ���� ª��
            print("���� ª��");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
