using UnityEngine;



public class SceneController : MonoBehaviour
{
    void Update()
    {
        // 获取 heroInjured 类的实例
        heroInjured hero = FindObjectOfType<heroInjured>();

        if (hero != null)
        {
            // 访问 heroInjured 类的 healthCnt 成员变量
            int Heroblood = hero.healthCnt;

            if (Heroblood <= 0)
            {
                LoadNextScene(); // 跳转到下一个场景
            }
            else
            {
                // 继续当前场景的逻辑
            }
        }
        else
        {
            Debug.LogWarning("heroInjured 类的实例未找到！");
        }
    }

    void LoadNextScene()
    {
        // 加载下一个场景，这里用的是Unity的方式，具体实现取决于你的游戏引擎
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
