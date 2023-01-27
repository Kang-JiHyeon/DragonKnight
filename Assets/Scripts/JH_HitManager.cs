using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �¾ �� imageHit�� ������ �ʵ��� �Ѵ�.
// ���� �÷��̾ �������� �� imageHit�� �����δ�.

// << ���� >>
// �¾ �� imageGameOver�� ������ �ʵ��� �Ѵ�.
// �÷��̾��� hp�� 0�� �Ǹ� imageGameOver�� Ȱ��ȭ�Ѵ�.
// imageGameOver�� Ȱ��ȭ���� 1�ʰ� ������
// textGameOver�� Ȱ��ȭ�ȴ�.
public class JH_HitManager : MonoBehaviour
{
    // static -> Ŭ���� ����, ������ ��ü, ���α׷� ���� �� �Ҵ�, ���� �� �Ҹ�
    // ���α׷� ���� ó������ ����, Ŭ������ ��
    public static JH_HitManager instance;
   // public GameObject imageHit;
    public Image imageBlack;

    // ��ũ��Ʈ�� ����� �� �ѹ���, Start �Լ� ���� ȣ���
    private void Awake()
    {
        // instance���� ��ü, �� HitManager ������Ʈ�� ���
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        imageBlack.gameObject.SetActive(false);
    }

    // GameOver UI ��� �Լ�
    public void ShowGameOver()
    {
        // �ڷ�ƾ �Լ� ȣ��
        StartCoroutine("IeFadeOut");
        
    }

    // �÷��̾� ��� �� Black �̹��� ���̵� ��
    IEnumerator IeFadeOut()
    {
        yield return new WaitForSeconds(3f);
        imageBlack.gameObject.SetActive(true);

        print("Fadeout");
        // ó�� ���� ��
        float alpha = 0f;
        // ���� ���� ������Ű�� �ʹ�.
        while (alpha < 1f)
        {
            alpha += 0.005f;
            yield return new WaitForSeconds(0.005f);
            imageBlack.color = new Color(0f, 0f, 0f, alpha);
        }

        JH_SceneManager.Instance.GameOver();
    }


    // Update is called once per frame
    void Update()
    {

    }
}
