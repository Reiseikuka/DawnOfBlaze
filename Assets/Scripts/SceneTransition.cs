using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad;

    public Vector2 playerPosition;
    public VectorValue playerStorage;
    //Reference which  position we're moving to

    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    
    public float fadeWait;
    //How long we want the panel without loading to always wait at least

    private void Awake()
    {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel,1);
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && ! other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            //SceneManager.LoadScene(sceneToLoad);

            StartCoroutine(FadeCo());
            /*Async operation = Loads the scene while  this one
              is there while the fade is going on*/
        }
    }

    public IEnumerator FadeCo()
    {
        if(fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
            yield return new WaitForSeconds(fadeWait);
            // After the scene fades out, wait an amount of time
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
            //While still is loading, wait and then one it's loaded, load it automatically 
            while(!asyncOperation.isDone)
            {
                yield return null;
            }
         }
    }
    // Only if the Transition Panel exists
    /*Controller so we can make pauses into our game*/

}
