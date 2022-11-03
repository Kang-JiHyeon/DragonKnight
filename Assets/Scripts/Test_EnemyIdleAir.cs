using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Test_EnemyIdleAir : MonoBehaviour
{
    public float motionTime = 1.8f;
    public float delta = 0.03f;                       // sin�� ����(���Ʒ� �ִ�ġ)
    public float speed = 6.3f;                       // ���� �ӵ�(speed)
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
                                       
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime < motionTime)
        {
            Vector3 pos = transform.position;               // �� ������ġ

            pos.y += delta * Mathf.Sin(Time.time * speed);  // y�������� Mathf.Sin�Լ��� ���·� �ӵ��� ���� ������. deltaTime�� ����ϸ� 1������ �� ������.
            transform.position = pos;
            
        }
        
        
    }
    
}
