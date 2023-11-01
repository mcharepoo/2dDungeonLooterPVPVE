

using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;


public class MainMenuButtonScripts : MonoBehaviour
{
    [SerializeField] int GameSceneBuildIndex = 1;

    public void LoadGameScene()
    {
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(GameSceneBuildIndex);

        // Optionally, you can disable the current scene's GameObjects during the loading process
        // For example, if you want to show a loading screen or loading progress bar.
        

        // Wait for the new scene to finish loading
        while (!asyncOperation.isDone)
        {
            // You can display a loading progress bar here by using asyncOperation.progress
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            yield return null;
        }

        // The new scene is now loaded and active
        // Re-enable any GameObjects you may have disabled earlier
        // EnableAllGameObjectsInNewScene();

        Debug.Log("Scene " + GameSceneBuildIndex + " loaded");
    }

   

    
}
