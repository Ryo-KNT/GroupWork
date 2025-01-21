using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RainbowJump.Scripts
{
    public class Rotator : MonoBehaviour
    {

        public float rotatingSpeed = 100f;
        // Start is called before the first frame update　Startは最初のフレームが更新される前に呼び出される

        // Update is called once per frame　1フレームに1回更新
        void Update()
        {
            transform.Rotate(0f, 0f, rotatingSpeed * Time.deltaTime);
        }
    }
}
