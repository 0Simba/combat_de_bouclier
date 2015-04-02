using UnityEngine;
using System.Collections;

public class AnimController : MonoBehaviour {

    private Animator animator;

    public MoveController moveController;
    public ProjectilesLauncher projectilesLauncher;

    void Start () {
        animator = GetComponent<Animator>();
    }


	void Update () {
        int state;

        if      (moveController._dashing)             state = 4; //dash
        else if (Mathf.Abs(moveController._velY) > 1) state = 3; //jump
        else if (Mathf.Abs(moveController._velX) > 1) state = 2; //run
        else if (projectilesLauncher.isLaunching)     state = 5; // throw
        else    state = 1; //idle

        animator.SetInteger("STATE", state);
    }

}
