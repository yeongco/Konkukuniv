using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool paused;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
        bool WhatBullet = true;
        public GameObject prefab1;
        public GameObject prefab2;
        public GameObject ShootPoint;

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

        public void OnChange()
        {
            if (paused) return;
            WhatBullet = !WhatBullet;
        }

        public void OnFire()
        {
			if (paused) return;
            if (WhatBullet)
            {
                GameObject clone = Instantiate(prefab1);
                clone.transform.position = ShootPoint.transform.position;
                clone.transform.rotation = ShootPoint.transform.rotation * Quaternion.Euler(90, 0, 0);
                SoundManager.Instance.PlaySFX("Bullet");
            }
            else
            {
                GameObject clone = Instantiate(prefab2);
                clone.transform.position = ShootPoint.transform.position;
                clone.transform.rotation = ShootPoint.transform.rotation;
                SoundManager.Instance.PlaySFX("Fire");
            }


        }

        public void OnPause(InputValue value)
        {
            ESCInput(value.isPressed);
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

        public void ESCInput(bool newESCState)
        {
            paused = !paused;
        }
    }
	
}