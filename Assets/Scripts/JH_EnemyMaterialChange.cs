using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy�� Material�� �����ϰ� �ʹ�.
// �ʿ�Ӽ�: ��Ƽ����, 
public class JH_EnemyMaterialChange : MonoBehaviour
{
    public SkinnedMeshRenderer enemyRender;
    private Material mat;
    public static JH_EnemyMaterialChange Instance;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyRender = GetComponent<SkinnedMeshRenderer>();
        mat = enemyRender.material;
    }
    public IEnumerator IeColorChange(float colorChangeTime = 0.1f)
    {
        mat.color = new Color(150 / 255f, 1, 1, 1); // ��Ӱ�
        yield return new WaitForSeconds(colorChangeTime);
        mat.color = Color.white;
    }
}
