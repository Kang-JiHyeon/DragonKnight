using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DestroyZone�� �˱Ⱑ ������ �˱Ⱑ ������� �ϰ� �ʹ�.
public class JH_DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ���� �ε��� �༮�� �� ���ش�.
        // ��, �Ѿ��� źâ�� �־�����
        if (other.gameObject.name.Contains("SwordAura"))
        {
            Destroy(other.gameObject);
        }
    }
}