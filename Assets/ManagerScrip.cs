using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ��ʼ��Ϸ����
    public void StartGame()
    {
        // �������д��ʼ��Ϸ���߼�
        SceneManager.LoadScene("GameScene"); // ������Ϸ����
    }
}
