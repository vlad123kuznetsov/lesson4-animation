using UnityEngine;

namespace Lesson4
{
    public abstract class BasePlatformerCharacter2D : MonoBehaviour
    {
        public abstract void Move(float move, bool crouch, bool jump);
    }
}