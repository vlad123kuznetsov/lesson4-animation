using System;
using Standard_Assets._2D.Scripts;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Lesson4
{
    public class Platformer2DUserControl : MonoBehaviour
    {
        [SerializeField]
        private BasePlatformerCharacter2D character;
        
        private bool IsJump;

        private void Update()
        {
            if (!IsJump)
            {
                IsJump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            var crouch = Input.GetKey(KeyCode.LeftControl);
            var h = CrossPlatformInputManager.GetAxis("Horizontal");
            character.Move(h, crouch, IsJump);
            IsJump = false;
        }
    }
}
