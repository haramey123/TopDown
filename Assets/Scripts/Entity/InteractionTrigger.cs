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
            interactionPopup.transform.position =  new Vector3(target.position.x, target.position.y + 1.5f, target.position.z); // �����̽��� ��ġ

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
            interactionPopup.SetActive(true); // �÷��̾ �����ϸ� �˾� ǥ��
            uiManager.EnableHighscore(PlayerPrefs.GetInt("Highscore", 0));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPopup.SetActive(false); // �÷��̾ ����� �˾� ����
            uiManager.DisableHighscore();
        }
    }
}
