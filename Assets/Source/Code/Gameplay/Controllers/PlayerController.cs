using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Gameplay
{
    public class PlayerController : SerializedMonoBehaviour
    {
        [SerializeField, TabGroup("Components")] private readonly List<Animator> _focusAnimators = new();

        private static readonly int FocusedKey = Animator.StringToHash("Focused");
        
        public void SetFocused(bool value)
        {
            _focusAnimators.ForEach(animator => animator.SetBool(FocusedKey, value));
        }
    }
}