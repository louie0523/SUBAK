using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] fruitPrefabs; // 1~9 ���� ���� ������
    public Transform[] spawnPoints;   // x�� ���� ���� ��ġ
    public float minY = -4f;          // y ���� �ּҰ�
    public float maxY = 4f;           // y ���� �ִ밪

    void Start()
    {
        SpawnInitialFruits();
    }

    void SpawnInitialFruits()
    {
        foreach (Transform point in spawnPoints)
        {
            int randomIndex = Random.Range(0, 3);
            Vector3 spawnPosition = new Vector3(point.position.x, point.position.y, point.position.z);
            Instantiate(fruitPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        }
    }
}