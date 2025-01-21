using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RainbowJump.Scripts
{
    public class ObstacleMovement : MonoBehaviour
    {
        public float startX = 5f; // starting position of the obstacle　障害物のスタート位置
        public float moveSpeed = 10f; // speed to move from startX to 0　startXから0までの移動速度
        public float returnSpeed = 2f; // speed to return from 0 to startX　0からstartXに戻る速度

        private bool movingToZero = true; // flag to indicate movement direction　移動方向を示すフラグ
        private Vector3 startPosition; // the initial position of the obstacle　障害物の初期位置

        void Start()
        {
            startPosition = transform.position;
        }

        void Update()
        {
            if (movingToZero)
            {
                // move towards 0 with moveSpeed　moveSpeedで0に近づく
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;

                // if the obstacle reaches 0, change direction　障害物が0になったら方向転換
                if (transform.position.x <= 0f)
                {
                    movingToZero = false;
                }
            }
            else
            {
                // move back towards startX with returnSpeed　returnSpeedでstartX方向に戻る。
                transform.position = Vector3.MoveTowards(transform.position, startPosition, returnSpeed * Time.deltaTime);

                // if the obstacle reaches startX, change direction　障害物がstartXに達したら方向転換
                if (transform.position.x >= startX)
                {
                    movingToZero = true;
                }
            }
        }
    }
}
