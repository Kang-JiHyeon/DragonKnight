using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float randx;
    float randz;
    float currentTime = 0f;
    float endTime = 6f;
    Vector3 dir;
    float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        randx = Random.Range(-0.1f, 0.1f);
        randz = Random.Range(-0.1f, 0.1f);
        dir = new Vector3(randx, -1, randz);
        dir.Normalize();

    }
    
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime < endTime)
        {
            if (transform.position.y >= 0.8f)
            {
                // ũ�Ⱑ Ŀ����
                transform.localScale += new Vector3(0.005f, 0, 0.005f);
                // �Ʒ��� �̵�
                transform.position += dir * speed * Time.deltaTime;
            }
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //�÷��̾�� �ε����� ������
        if (other.gameObject.name.Contains("Player"))
        {
            if (!JH_PlayerHP.Instance.isDamage)
            {
                JH_PlayerHP.Instance.addDamage();
            }

        }
    }
}
