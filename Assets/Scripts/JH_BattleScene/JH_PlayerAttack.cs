using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// �÷��̾ ����Ű�� ������ �ִϸ��̼��� ����ǰ� �ϰ� �ʹ�.
// ���� �ִϸ��̼��� ������ ���� ����Ű�� ������ ���� ���� �ִϸ��̼��� �Ѵ�.
// 1. ����Ű�� ������.
// 2. �ִϸ��̼��� ���� ������ Ȯ���Ѵ�.
// 3. �ִϸ��̼��� ���� ������ ������ �ִϸ��̼��� �����Ѵ�.
// 4. �׷��� ������ �ִϸ��̼��� �������� �ʴ´�. 



// �÷��̾ ���� Ű�� ���� ������ �˱⸦ ����� �ʹ�.
// �ʿ�Ӽ�: �˱����, �˱�
public class JH_PlayerAttack : MonoBehaviour
{
    public GameObject swordAuraFactory;
    public JH_SwordEffect sword;
    public AudioSource swingSound;
    JH_Player player;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        player = GetComponent<JH_Player>();
    }

    int attackCount = 3;
    int curAttackCount = 0;
    // Update is called once per frame
    void Update()
    {
        // �ִϸ��̼� ���� ������ ���� ��
        if (!(player.anim.GetCurrentAnimatorStateInfo(0).IsName("ATK0") || player.anim.GetCurrentAnimatorStateInfo(0).IsName("ATK2") || player.anim.GetCurrentAnimatorStateInfo(0).IsName("ATK3")))
        {
            player.isAttack = false;
        }
        
        
        // ���� ����Ű�� ������
        if (Input.GetKeyDown(KeyCode.C))
        {
            curAttackCount++;

            if (curAttackCount > attackCount)
            {
                
                StartCoroutine("IeDelay");
            }

            if (!player.isAttack) { 
                player.isAttack = true;

                //�޺� ������ �Ѵ�.
                player.anim.SetTrigger("doCombo");

                // �Ҹ� ���
                swingSound.Play();

                GameObject swordAura = Instantiate(swordAuraFactory);
                // �˱��� ��ġ�� �÷��̾��� ��ġ�� �����Ѵ�.
                swordAura.transform.position = transform.position;

                if(sceneName == "Tutorial")
                {
                    print("!!!!!11111111");
                    swordAura.transform.forward = -transform.forward;
                }
                else
                {
                    // �˱��� �չ����� �÷��̾��� �չ������� �����Ѵ�.
                    swordAura.transform.forward = transform.forward;
                }

            }
        }
    }
    
    IEnumerator IeDelay() 
    {
        yield return new WaitForSeconds(1f);
        curAttackCount = 0;
        player.isAttack = false;
    }

}
