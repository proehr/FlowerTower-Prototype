using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tower
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private bool busy;

        private void OnTriggerStay(Collider other)
        {
            if (busy)
            {
                return;
            }
            StartCoroutine(AttackEnemy(other.gameObject));
        }

        private IEnumerator AttackEnemy(GameObject other)
        {
            busy = true;
            animator.SetTrigger("Attack");
            float time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

            yield return new WaitForSeconds(time/2);
            DestroyImmediate(other);
            StartCoroutine(PrepareForNextAttack(time/2 + 4));
            
        }

        private IEnumerator PrepareForNextAttack(float time)
        {
            yield return new WaitForSeconds(time);
            busy = false;
        }
    }
}