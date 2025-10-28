using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InteractionTrigger : MonoBehaviour
{
    public GameObject interactionPopup;
    public Transform target;

    public string miniGameSceneName = "FlappyPlaneScene";

    UIManager uiManager;
    void Start()
    {
        uiManager = UIManager.Instance;
    }

    private void Update()
    {
        if (interactionPopup.activeSelf)
        {
            interactionPopup.transform.position =  new Vector3(target.position.x, target.position.y + 1.5f, target.position.z); // 스페이스바 위치

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
            interactionPopup.SetActive(true); // 플레이어가 접근하면 팝업 표시
            uiManager.EnableHighscore(PlayerPrefs.GetInt("Highscore", 0));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPopup.SetActive(false); // 플레이어가 벗어나면 팝업 숨김
            uiManager.DisableHighscore();
        }
    }
}
