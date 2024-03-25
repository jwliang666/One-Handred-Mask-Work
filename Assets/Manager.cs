using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 开始游戏方法
    public void StartGame()
    {
        // 在这里编写开始游戏的逻辑
        SceneManager.LoadScene("GameScene"); // 加载游戏场景
    }
}
