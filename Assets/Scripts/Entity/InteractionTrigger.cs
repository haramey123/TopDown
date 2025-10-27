using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InteractionTrigger : MonoBehaviour
{
    public GameObject interactionPopup;
    public Transform target;

    public string miniGameSceneName = "FlappyPlaneScene";

    private void Update()
    {
        if (interactionPopup.activeSelf)
        {
            interactionPopup.transform.position =  new Vector3(target.position.x, target.position.y + 1.5f, target.position.z);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EnterMiniGame();
            }
        }
    }

    private void EnterMiniGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(miniGameSceneName);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPopup.SetActive(true); // ÇÃ·¹ÀÌ¾î°¡ Á¢±ÙÇÏ¸é ÆË¾÷ Ç¥½Ã
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPopup.SetActive(false); // ÇÃ·¹ÀÌ¾î°¡ ¹þ¾î³ª¸é ÆË¾÷ ¼û±è
        }
    }
}
