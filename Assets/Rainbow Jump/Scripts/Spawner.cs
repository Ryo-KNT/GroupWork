using UnityEngine;
using System.Collections.Generic;

namespace RainbowJump.Scripts
{

    public class Spawner : MonoBehaviour
    {
        public List<GameObject> obstacles;
        public Transform spawnPoint;
        public float yOffset = 4.0f;
        public float spawnInterval = 0.9f;
        private float timer = 0.0f;

        private static List<GameObject> spawnedObstacles = new List<GameObject>();

        void Start()
        {
            InitializeObstacles();
        }

        public void InitializeObstacles()
        {
            // Initialize 2 obstacles at start スタート時に2つの障害物を初期化
            for (int i = 0; i < 2; i++)
            {
                SpawnObstacle();
            }
        }

        void Update()
        {
            timer += Time.deltaTime;



            if (timer >= spawnInterval)
            {
                // Reset the timer and execute the code タイマーをリセットし、コードを実行する
                timer = 0.0f;
                SpawnObstacle();
            }


            // Spawn a new obstacle every spawnInterval seconds スポーンインターバルごとに新しい障害物を生成する
            //InvokeRepeating("SpawnObstacle", 0.1f, spawnInterval);繰り返す
        }

        void SpawnObstacle()
        {
            // Choose a random obstacle from the list　リストからランダムに障害物を選ぶ
            GameObject obstaclePrefab = obstacles[Random.Range(0, obstacles.Count)];

            // Calculate the spawn position of the obstacle　障害物のスポーン位置を計算する
            Vector3 spawnPosition = spawnPoint.position + Vector3.up * yOffset * spawnedObstacles.Count;

            // Instantiate the obstacle at the spawn position　スポーン位置に障害物をインスタンス化する。
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            // Add the obstacle to the list of spawned obstacles　障害物をスポーンされた障害物のリストに追加する。
            spawnedObstacles.Add(obstacle);

            // Set the parent of the obstacle to the "Obstacles" GameObject　障害物の親を 「Obstacles 」GameObjectに設定する。
            obstacle.transform.SetParent(transform);
        }

        public void DestroyAllObstacles()
        {
            foreach (GameObject obstacle in spawnedObstacles)
            {
                Destroy(obstacle);
            }

            spawnedObstacles.Clear();
        }

    }
}
