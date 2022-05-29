using UnityEngine;

namespace Core
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private InputAxis axis;
        private IPlayerInput inputSource;

        private void Awake()
        {
            inputSource = GetInputSource();
        }

        private void Update()
        {
            axis.State = inputSource.GetAxisState();
        }

        private IPlayerInput GetInputSource()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                case RuntimePlatform.IPhonePlayer:
                    return new TouchInput();
                
                default:
                    return new KeyboardInput();
            }
        }
    }
}