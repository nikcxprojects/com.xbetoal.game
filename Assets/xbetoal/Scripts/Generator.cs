using UnityEngine;

public class Generator : MonoBehaviour
{
    private GameObject Prefab { get; set; }
    public static Transform Target { get; set; }

    private void Awake()
    {
        Prefab = Resources.Load<GameObject>("obstacle");
    }

    private void Update()
    {
        if(!Target)
        {
            return;
        }

        if(Target.position.y > transform.position.y)
        {
            SpawnObstacles();
            transform.position += Vector3.up * 35;
        }
    }

    private void SpawnObstacles()
    {
        var count = 5;

        for(int i = 0; i < count; i++)
        {
            var x = Random.Range(-1.836f, 1.836f);
            var y = (transform.position.y + 10) + i * 5;

            var obstacle = Instantiate(Prefab, transform.parent);
            obstacle.transform.position = new Vector3(x, y);
        }
    }
}
