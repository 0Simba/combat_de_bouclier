using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	public float decX = 0.1f;
	public float maxSpeed = 3;
	public float timeToMaxSpeed = 1;

	public float decXInAir = 0.1f;
	public float maxSpeedInAir = 3;
	public float timeToMaxSpeedInAir = 02;

	private float _velX = 0;

	public float normalGravity = 10;
	public float boostedGravity = 20;

	public float boostXWallJump = 10;

	public float jumpInitialVel  = 20;
	public float jumpContinuousVel = 5;
	public float jumpFall = 5;
	public float maxJumpDuration = 0;

	private float _jumpButtonPressedFor = 0;
	private float _velY = 0;
	private bool _jumping = false;
	private bool _grounded = false;

	private CharacterController2D _characterController;
	// Use this for initialization
	void Start () {
		_characterController = GetComponent<CharacterController2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (_grounded) {
			moveX(maxSpeed, timeToMaxSpeed, decX);
		} else {
			moveX(maxSpeed, timeToMaxSpeed, decXInAir);
		}

		UpdateJump ();
		_characterController.move (((_velX * Vector3.right) + (_velY * Vector3.up)) * Time.deltaTime);
		if (_characterController.collisionState.below) {
			_velY = 0;
			_grounded = true;
		} else {
			_grounded = false;
		}
		if (_characterController.collisionState.above) {
			_velY = 0;
		}
	}

	void UpdateJump() {
		_velY -= Time.deltaTime * (_jumping && _velY<0 ? boostedGravity : normalGravity);
		if (DeviceManager.currentDevice.RightBumper.WasPressed && !_jumping) {
			if(_grounded) {
				_velY = jumpInitialVel;
				_jumping = true;
				_jumpButtonPressedFor = 0;
			} else if (_characterController.collisionState.left && DeviceManager.currentDevice.LeftStickX<0) {
				_velX += boostXWallJump;
				_velY = jumpInitialVel;
				_jumping = true;
				_jumpButtonPressedFor = 0;
			} else if (_characterController.collisionState.right && DeviceManager.currentDevice.LeftStickX>0) {
				_velX -= boostXWallJump;
				_velY = jumpInitialVel;
				_jumping = true;
				_jumpButtonPressedFor = 0;
			}

		} else {
			if (_grounded || _characterController.collisionState.side) {
				_jumping = false;
			}
		}

		if (DeviceManager.currentDevice.RightBumper.WasReleased && _jumping && (_velY > jumpFall)) {
			_velY = jumpFall;
		}
		if (DeviceManager.currentDevice.LeftBumper.IsPressed &&
		    _jumping &&
		    //(_velY > jumpContinuousVel) &&
		    _jumpButtonPressedFor < maxJumpDuration
		) {
			_velY += jumpContinuousVel * Time.deltaTime;
			_jumpButtonPressedFor += Time.deltaTime;
		}
	}

	void moveX(float maxSpeed, float timeToMaxSpeed, float decX) {
		float dx = DeviceManager.currentDevice.LeftStickX;
		if (Mathf.Abs (dx * maxSpeed) >= Mathf.Abs (_velX)) {
			_velX += maxSpeed / timeToMaxSpeed * Time.deltaTime * dx;
			if (Mathf.Abs (_velX) > maxSpeed) {
				_velX = maxSpeed * Mathf.Sign(_velX);
			}
		} else {
			_velX *= decX;
		}
	}
}
