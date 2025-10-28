using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float highPosY = 1.5f;
    private float lowPosY = -1.5f;

    private float holeSizeMin = 1f;
    private float holeSizeMax = 2f;

    public Transform topObject;
    public Transform bottomObject;

    private float widthPadding = 4f;

    FPGameManager gameManager;

    private void Start()
    {
        gameManager = FPGameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        // 구멍 크기 랜덤 설정
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;

        // 부모 오브젝트를 기준으로 구멍 크기 조정
        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        // 마지막 장애물을 기준으로 x 위치 조정
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        // 장애물 전체의 위 아래 위치 조정
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
