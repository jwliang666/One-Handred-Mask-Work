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
            // 加载下一个场景，假设下一个场景的名称为 "NextScene"
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
