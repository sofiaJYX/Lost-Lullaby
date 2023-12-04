using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad = "CaveScene";

    // initiate the scene transition
    public void TransitToNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // change the tag to match your player's tag
        {
            TransitToNextScene();
        }
    }
}
