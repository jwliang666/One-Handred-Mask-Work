using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager1 : MonoBehaviour
{
    public int monsterCount;

    GameObject monsterManager;
    private monsterManage monsterManage;
    void Start()
    {
        monsterManager = GameObject.Find("monsterManager");
        monsterManage = monsterManager.GetComponent<monsterManage>();
        
    }
    
    void Update()
    {
        monsterCount = monsterManage.monsterCnt;
   
    
        if (monsterCount <= 0)
        {
            // ������һ��������������һ������������Ϊ "NextScene"
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
