using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���߿��� �÷��̾� ������ �̵�
// �ʿ��Ѱ� : �ӵ�, ����, ��ǥ

public class Test_EnemyAirToLand : MonoBehaviour
{
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3.zero;
        dir.y = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, dir, 0.02f);

    }
}
