using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public float transitionDuration = 1.0f;
    public CanvasGroup canvasGroup;

    public IEnumerator TransitionToNextScene()
    {
        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            // 计算当前的不透明度
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / transitionDuration);
            // 设置 Canvas Group 的不透明度
            canvasGroup.alpha = alpha;
            // 增加已过时间
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 加载下一个场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartMenu()
    {
        StartCoroutine(TransitionToNextScene());
    }
}
