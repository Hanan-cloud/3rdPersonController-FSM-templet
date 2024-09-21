using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public static PlayerAnimation instance;

    private Animator animator;


    readonly int idle = Animator.StringToHash("Idle");
    readonly int walk = Animator.StringToHash("Walk");
    readonly int run = Animator.StringToHash("FastRun");
    readonly int jump = Animator.StringToHash("Jump");
    readonly int climb = Animator.StringToHash("Climb");
    readonly int cruoch = Animator.StringToHash("Crouch");
    readonly int move = Animator.StringToHash("movement");

    int _currentAnim;
    int _nextAnim;


    int speedHash = Animator.StringToHash("RunSpeed");


    public void ChangeAnimation(PlayerStates anim)
    {
      
        switch (anim)
        {
            case PlayerStates.idle:
                _nextAnim = idle;
                print("idle " + idle);
                break;
            case PlayerStates.walk:
                _nextAnim = walk;
                print("walking " + walk);

                break;
            case PlayerStates.run:
                _nextAnim = run;
                break;
            case PlayerStates.climb:
                _nextAnim = climb;
                break;
            case PlayerStates.crouch:
                _nextAnim = cruoch;
                break;
            case PlayerStates.move:
                _nextAnim = move;
                break;
            default:
                _nextAnim = idle;
                break;
        }

        if (_currentAnim == _nextAnim)
            return;

        //animator.Play(anim);
        _currentAnim = _nextAnim;
        animator.CrossFade(_currentAnim,0.25f);
    }


    public void SetBlend(float animParameter)
    {
        animator.SetFloat(speedHash, animParameter);

    }



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
      //  StartCoroutine(stg());
    }
    IEnumerator stg()
    {
        yield return new WaitForSeconds(3);
        animator.CrossFade(walk, 0.25f);
        yield return new WaitForSeconds(3);
        animator.CrossFade(run, 0.25f);

    }


}
