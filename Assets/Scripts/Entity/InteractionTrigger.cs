using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    public GameObject interactionPopup;  // ��ȣ�ۿ� �ȳ� UI (�����Ϳ��� ����)


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPopup.SetActive(true); // �÷��̾ �����ϸ� �˾� ǥ��
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPopup.SetActive(false); // �÷��̾ ����� �˾� ����
        }
    }
}
