using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ʈ���� �߻���
// �÷��̾����� Ȯ��
// ������ �Լ� ȣ��

public class EnemyAddDamage : MonoBehaviour
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
        if (other.gameObject.name.Contains("Player"))
        {
            
            JH_PlayerHP.Instance.addDamage();
            
            
        }
    }
}
