using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] fruitPrefabs; // 1~9 숫자 과일 프리팹
    public Transform[] spawnPoints;   // x값 고정 스폰 위치
    public float minY = -4f;          // y 랜덤 최소값
    public float maxY = 4f;           // y 랜덤 최대값

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