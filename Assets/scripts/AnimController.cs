using UnityEngine;
using System.Collections;

public class AnimController : MonoBehaviour {

    public Animator[] animator;

    public MoveController      moveController;
    public ProjectilesLauncher projectilesLauncher;
    public EquipmentController equipmentController;


    private int  lastState = 0;
    private bool keepFrame = false;

	void Update () {
        if (keepFrame) {
            keepFrame = false;
            return;
        }

        int state;

        if      (equipmentController.isDead)          state = 6; //death
        else if (projectilesLauncher.isLaunching)     state = 5; //throw
        else if (moveController._dashing)             state = 4; //dash
        else if (Mathf.Abs(moveController._velY) > 1) state = 3; //jump
        else if (Mathf.Abs(moveController._velX) > 1) state = 2; //run
        else    state = 1; //idle


        if (state == 5) {
            keepFrame = true;
        }

        if (lastState != state) {
            for (int i = 0; i < animator.Length; i++) {
                animator[i].SetInteger("STATE", state);
            }
        }
        lastState = state;
    }

}
