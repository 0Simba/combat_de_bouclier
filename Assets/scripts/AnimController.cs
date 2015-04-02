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

        if      (moveController._dashing)         state = 2; //dash
        else if (moveController._velY != 0)       state = 3; //jump
        else if (moveController._velX != 0)       state = 4; //run
        else if (projectilesLauncher.isLaunching) state = 4; // throw
        else    state = 1;

        animator.SetInteger("STATE", state);
    }

}
