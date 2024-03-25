using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    public int healthblood; // ����������Ľ���Ѫ������
    public int monsternum;
    private heroInjured heroInjured;
    private monsterManage monsterManage;

    void Update()
    {
        GameObject hero = GameObject.Find("hero");
        heroInjured = hero.GetComponent<heroInjured>();
        healthblood = heroInjured.healthCnt;

        GameObject monsterManager = GameObject.Find("monsterManager");
        monsterManage = monsterManager.GetComponent<monsterManage>();
        monsternum = monsterManage.monsterCnt; // ʹ�� monsterManage ������� monsterCnt ����



        if (healthblood <= 0)
        {
            LoadNextScene(); // ��ת����һ������
        }
        else
        {
            // ������ǰ�������߼�
        }
        if (monsternum <= 0)
        {
            LoadNextNextScene();
        }
        else
        {

        }
    }

    void LoadNextScene()
    {
        // ������һ�������������õ���Unity�ķ�ʽ������ʵ��ȡ���������Ϸ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void LoadNextNextScene()
    {
        // ������һ�������������õ���Unity�ķ�ʽ������ʵ��ȡ���������Ϸ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}