using UnityEngine;

namespace RainbowJump.Scripts
{
    public class DestroyObstacle : MonoBehaviour
    {
        private Camera mainCamera;

        void Start()
        {
            // Get a reference to the MainCamera　MainCameraへの参照を取得する。
            mainCamera = Camera.main;
        }

        void Update()
        {
            // Check if the gameobject's y position is less than the MainCamera's position -7　gameobjectのy位置がMainCameraの位置より-7小さいかチェックする 
            if (transform.position.y < mainCamera.transform.position.y - 7.0f && gameObject.CompareTag("Obstacle"))
            {
                // Destroy the gameobject　ゲームオブジェクトを破壊する
                Destroy(gameObject);
            }
        }
    }
}