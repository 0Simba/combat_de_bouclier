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

	public float dashSpeed = 20;
	public float dashDesc = 0.9f;
	public float dashMinSpeed = 2;
	public float dashBounce = 0.5F;
	public uint maxDash = 1;
	private uint _dashed = 0;
	private float _curentDashSpeed; 
	private bool _dashing = false;
	public float dashBounceAngle = 0.8f;
	private Vector2 _dashDirection = Vector2.zero;

	private CharacterController2D _characterController;
	private MainPlayer            mainPlayer;

	void Start () {
		mainPlayer = GetComponent<MainPlayer>();
		_characterController = GetComponent<CharacterController2D> ();
	}


	void Update () {

		if (!_dashing) {
			if (_grounded) {
				moveX (maxSpeed, timeToMaxSpeed, decX);
			} else {
				moveX (maxSpeed, timeToMaxSpeed, decXInAir);
			}

			UpdateJump ();
			Dash ();
		} else {
			UpdateDash();
		}

		_characterController.move (((_velX * Vector3.right) + (_velY * Vector3.up)) * Time.deltaTime);
		if (_characterController.collisionState.below) {
			_velY = 0;
			_grounded = true;
			if (!_dashing) {_dashed = 0;};
		} else {
			_grounded = false;
		}
		if (_characterController.collisionState.above) {
			_velY = 0;
		}

	}

	void UpdateJump() {
		_velY -= Time.deltaTime * (_jumping && _velY<0 ? boostedGravity : normalGravity);
		InControl.InputDevice gamepad = DeviceManager.devices [mainPlayer.deviceIndex];
		if (gamepad.RightBumper.WasPressed && !_jumping) {
			if(_grounded) {
				_velY = jumpInitialVel;
				_jumping = true;
				_jumpButtonPressedFor = 0;
			} else if (_characterController.collisionState.left && gamepad.LeftStickX<0) {
				_velX += boostXWallJump;
				_velY = jumpInitialVel;
				_jumping = true;
				_jumpButtonPressedFor = 0;
			} else if (_characterController.collisionState.right && gamepad.LeftStickX>0) {
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

		if (gamepad.RightBumper.WasReleased && _jumping && (_velY > jumpFall)) {
			_velY = jumpFall;
		}
		if (gamepad.LeftBumper.IsPressed &&
		    _jumping &&
		    //(_velY > jumpContinuousVel) &&
		    _jumpButtonPressedFor < maxJumpDuration
		) {
			_velY += jumpContinuousVel * Time.deltaTime;
			_jumpButtonPressedFor += Time.deltaTime;
		}
	}

	void Dash() {
		InControl.InputDevice gamepad = DeviceManager.devices [targetDevice];
		if (gamepad.LeftTrigger.WasPressed && _dashed < maxDash) {
		InControl.InputDevice gamepad = DeviceManager.devices [mainPlayer.deviceIndex];
		if (gamepad.LeftTrigger.WasPressed) {
			_dashDirection = new Vector2(gamepad.LeftStickX,gamepad.LeftStickY);
			_curentDashSpeed = dashSpeed;
			_jumping = false;
			_dashing = true;
			_dashed++;
		}
	}

	void UpdateDash() {
		_velX = _curentDashSpeed * _dashDirection.x;
		_velY = _curentDashSpeed * _dashDirection.y;
		_curentDashSpeed *= dashDesc;
		if (_curentDashSpeed < dashMinSpeed) {
			_dashing = false;
			if (_velY>0) {
				_velY = 0;
			}
		}
		if (_characterController.collisionFlags > 0) {
			//We need to do a ligne cast to the center of the player in the direction of the element to check if we
			//We are smashing into a wall or just following it
			RaycastHit2D hit = Physics2D.Raycast(transform.position,_dashDirection,Mathf.Infinity,_characterController.platformMask);
			if (hit.collider != null && 
			    Vector2.Dot(hit.normal, _dashDirection.normalized) < -dashBounceAngle && 
			    _curentDashSpeed < dashSpeed * dashDesc * dashDesc
			) {

				_dashing = false;
				_velX = -_velX * dashBounce;
				_velY = -_velY * dashBounce;
			}

		}
	}

	void moveX(float maxSpeed, float timeToMaxSpeed, float decX) {
		float dx = DeviceManager.devices[mainPlayer.deviceIndex].LeftStickX;
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
