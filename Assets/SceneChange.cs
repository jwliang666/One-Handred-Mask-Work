using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public int healthblood; // 假设这是你的健康血量变量
    public int monsternum;
    private heroInjured heroInjured;
    private monsterManage monsterManage;

    public int healthblood2;
    private bsheep bsheep;


    void Update()
    {
        GameObject hero = GameObject.Find("hero");
        heroInjured = hero.GetComponent<heroInjured>();
        healthblood = heroInjured.healthCnt;

        GameObject hero1 = GameObject.Find("bssheep");
        bsheep = hero1.GetComponent<bsheep>();
        healthblood2 = bsheep.bssheephealth;

        GameObject monsterManager = GameObject.Find("monsterManager");
        monsterManage = monsterManager.GetComponent<monsterManage>();
        monsternum = monsterManage.monsterCnt; // 使用 monsterManage 对象访问 monsterCnt 属性



        if (healthblood <= 0 || healthblood2 <= 0)
        {
            LoadNextScene(); // 跳转到下一个场景
        }
        else
        {
            // 继续当前场景的逻辑
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
        // 加载下一个场景，这里用的是Unity的方式，具体实现取决于你的游戏引擎
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void LoadNextNextScene()
    {
        // 加载下一个场景，这里用的是Unity的方式，具体实现取决于你的游戏引擎
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }
}
