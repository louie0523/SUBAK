using UnityEngine;

public class FruitController : MonoBehaviour
{

    public static FruitController instance;

    public float GRAVITY_SCALE = 2f; // 떨어질 때 중력
    public float INIT_Y_POS = 18f;   // 오브젝트 시작 y 위치
    public float MinX = -9f;
    public float MaxX = 9f;



    public GameObject[] fruitPrefabs; // 1~3 숫자 과일 프리팹
    public GameObject spawnObject;   // 현재 생성된 오브젝트


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

        // 마우스 커서 위치 따라가기
        FollowMouseCursor();

        // 마우스 우클릭 시 오브젝트 떨어뜨리기
        if (Input.GetMouseButtonDown(1))
        {
            DropObject();
        }
    }

    private void FollowMouseCursor()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // x 위치를 MinX ~ MaxX 범위로 제한
        mousePos.x = Mathf.Clamp(mousePos.x, MaxX, MinX);

        // y, z 고정
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
            rb.gravityScale = GRAVITY_SCALE; // 떨어지게
        }
        fruit.isDrop = false;
        spawnObject = null;
    }

    public void SpawnNewFruit()
    {
        if(GameManager.instance.isEnd) return;
        // 1~3 숫자 과일만 랜덤 선택
        int randomIndex = Random.Range(0, 3);
      
        spawnObject = Instantiate(fruitPrefabs[randomIndex], new Vector3(0, INIT_Y_POS, 0), Quaternion.identity);

        // 떨어지기 전에는 중력 제거
        Rigidbody2D rb = spawnObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.gravityScale = 0f;
        }
    }


}