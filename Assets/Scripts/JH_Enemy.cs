using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ���� ����� ���̸� ���� �������� ����
// ���� ���� ����� �÷��̾��̸� �÷��̾��� �������� ����
// �ʿ�Ӽ� : �÷��̾� HP, �� HP, 
public class JH_Enemy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾��� ���ݿ� ������ �������� �Դ´�. 
        if (other.gameObject.name.Contains("Player"))
        {
            if (!JH_PlayerHP.Instance.isDamage)
            {
                JH_PlayerHP.Instance.addDamage();
            }
        }

        // �˱Ⱑ ������ �˱� �ٽ� ä��
        //if (other.gameObject.name.Contains("SwordAura"))
        //{
        //    GameObject target = GameObject.Find("Player");
        //    JH_PlayerAttack player = target.GetComponent<JH_PlayerAttack>();
        //    player.SwordAuraPool.Add(other.gameObject);
        //    other.gameObject.SetActive(false);

        //    print("SwordAura Collision");
        //}

    }
}
