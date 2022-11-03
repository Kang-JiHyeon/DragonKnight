using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �����Ǹ� �����ð��ڿ� �÷��̾ ������ ���ư���
// �ʿ��Ѱ� : �ð�, �÷��̾�, �ӵ�, �˵�

public class Magic : MonoBehaviour
{
    float currentTime = 0;
    float upTime = 2f;
    float fireTime = 3f;
    
    GameObject target;
    Vector3 attackPos;
    public float upSpeed = 20f;
    public float chaseSpeed = 130f;
    Vector3 dir;
    float randz = 0;
    public float x = -0.5f;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        randz = Random.Range(-1f, 1f);
        

        dir = new Vector3(x, 1, randz);
        dir.Normalize();



    }

    // Update is called once per frame
    void Update()
    {
        // �ð��� �帣��
        currentTime += Time.deltaTime;


        if (currentTime > fireTime)
        {
            transform.position += (attackPos + Vector3.forward).normalized * chaseSpeed * Time.deltaTime;

        }
        else if (currentTime > upTime && currentTime < fireTime)
        {
            transform.position += dir * upSpeed * Time.deltaTime;
            attackPos = target.transform.position - transform.position;

        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            
            JH_PlayerHP.Instance.addDamage();
            Destroy(gameObject);
            
        }
       
        // ���� �ٸ��Ŷ� �ε����� ��
        // ���� �ı�
        
    }
}
    
   
