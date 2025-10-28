using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 1.5f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        // ���� ũ�� ���� ����
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;

        // �θ� ������Ʈ�� �������� ���� ũ�� ����
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        // ������ ��ֹ��� �������� x ��ġ ����
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        // ��ֹ� ��ü�� �� �Ʒ� ��ġ ����
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null && !gameManager.isDead)
        {
            gameManager.AddScore(1);
        }
    }
}
