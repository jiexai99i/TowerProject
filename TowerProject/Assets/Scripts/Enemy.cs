using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int target = 0;
    public Transform exit;
    public Transform[] points;
    public float navigation;

    private Transform enemy;
    private float navigationTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (points != null)
        {
            navigationTime += Time.deltaTime;
            if (navigationTime > navigation)
            {
                if (target < points.Length)
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, points[target].position, navigationTime);
                }

                else
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, exit.position, navigationTime);
                }
                navigationTime = 0;
            }
        }
                    
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Point")
        {
            target += 1;
        }
        else if (collision.tag == "Finish")
        {
            Manager.Instance.RemoveEnemyFromScrenn();
            Destroy(gameObject);
        }

    }

}
