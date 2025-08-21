using UnityEngine;

public class FruitController : MonoBehaviour
{

    public static FruitController instance;

    public float GRAVITY_SCALE = 2f; // ������ �� �߷�
    public float INIT_Y_POS = 18f;   // ������Ʈ ���� y ��ġ
    public float MinX = -9f;
    public float MaxX = 9f;



    public GameObject[] fruitPrefabs; // 1~3 ���� ���� ������
    public GameObject spawnObject;   // ���� ������ ������Ʈ


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SpawnNewFruit();
    }

    private void Update()
    {
        if (spawnObject == null) return;

        // ���콺 Ŀ�� ��ġ ���󰡱�
        FollowMouseCursor();

        // ���콺 ��Ŭ�� �� ������Ʈ ����߸���
        if (Input.GetMouseButtonDown(1))
        {
            DropObject();
        }
    }

    private void FollowMouseCursor()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // x ��ġ�� MinX ~ MaxX ������ ����
        mousePos.x = Mathf.Clamp(mousePos.x, MaxX, MinX);

        // y, z ����
        mousePos.y = spawnObject.transform.position.y;
        mousePos.z = 0;

        spawnObject.transform.position = mousePos;
    }


    private void DropObject()
    {
        Rigidbody2D rb = spawnObject.GetComponent<Rigidbody2D>();
        Fruit fruit = spawnObject.GetComponent<Fruit>();
        if (rb != null)
        {
            rb.gravityScale = GRAVITY_SCALE; // ��������
        }
        fruit.isDrop = false;
        spawnObject = null;
    }

    public void SpawnNewFruit()
    {
        if(GameManager.instance.isEnd) return;
        // 1~3 ���� ���ϸ� ���� ����
        int randomIndex = Random.Range(0, 3);
      
        spawnObject = Instantiate(fruitPrefabs[randomIndex], new Vector3(0, INIT_Y_POS, 0), Quaternion.identity);

        // �������� ������ �߷� ����
        Rigidbody2D rb = spawnObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
        }
    }


}