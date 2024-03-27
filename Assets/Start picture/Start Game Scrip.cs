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
            // ���㵱ǰ�Ĳ�͸����
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / transitionDuration);
            // ���� Canvas Group �Ĳ�͸����
            canvasGroup.alpha = alpha;
            // �����ѹ�ʱ��
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ������һ������
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartMenu()
    {
        StartCoroutine(TransitionToNextScene());
    }
}
