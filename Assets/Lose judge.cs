using UnityEngine;



public class SceneController : MonoBehaviour
{
    void Update()
    {
        // ��ȡ heroInjured ���ʵ��
        heroInjured hero = FindObjectOfType<heroInjured>();

        if (hero != null)
        {
            // ���� heroInjured ��� healthCnt ��Ա����
            int Heroblood = hero.healthCnt;

            if (Heroblood <= 0)
            {
                LoadNextScene(); // ��ת����һ������
            }
            else
            {
                // ������ǰ�������߼�
            }
        }
        else
        {
            Debug.LogWarning("heroInjured ���ʵ��δ�ҵ���");
        }
    }

    void LoadNextScene()
    {
        // ������һ�������������õ���Unity�ķ�ʽ������ʵ��ȡ���������Ϸ����
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
