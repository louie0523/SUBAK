using UnityEngine;

public class Fruit : MonoBehaviour
{
    public bool isDrop = true;
    public bool hasLanded = false;
    public bool isMerging = false;   // 합쳐지는 중인지 체크
    public int num;

    private void OnCollisionStay2D(Collision2D collision)
    {
        TryMerge(collision);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TryMerge(collision);
    }

    private void TryMerge(Collision2D collision)
    {
        if (isDrop) return;

        // 땅에 닿았을 때
        if (!collision.gameObject.CompareTag("Wall") && !hasLanded)
        {
            hasLanded = true;
            if (FruitController.instance.spawnObject == null)
                FruitController.instance.SpawnNewFruit();
            Debug.Log("과일이 땅에 닿음");
        }

        // 과일끼리 합치기
        Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();
        if (otherFruit != null)
        {
            if (num == otherFruit.num && !isMerging && !otherFruit.isMerging && num + 1 <= 10)
            {
                isMerging = true;
                otherFruit.isMerging = true;

                Vector3 spawnPos = (transform.position + otherFruit.transform.position) / 2f;
                GameObject newFruit = Instantiate(FruitController.instance.fruitPrefabs[num], spawnPos, Quaternion.identity);

                Rigidbody2D rb = newFruit.GetComponent<Rigidbody2D>();
                rb.gravityScale = FruitController.instance.GRAVITY_SCALE;

                Fruit newFruitSc = newFruit.GetComponent<Fruit>();
                newFruitSc.num = num + 1;
                newFruitSc.isDrop = false;
                newFruitSc.hasLanded = true;

                GameManager.instance.Score += 100 + (num * 400);
                Destroy(otherFruit.gameObject);
                Destroy(gameObject);
            }
        }
    }

}
