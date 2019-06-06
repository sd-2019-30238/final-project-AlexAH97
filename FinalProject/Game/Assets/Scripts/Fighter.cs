﻿using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using RPG.Movement;
using UnityEngine;
namespace RPG.Combat{
    public class Fighter : MonoBehaviour,IAction
    {
       
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks=1f;
        [SerializeField] float weaponDamage = 5f;
        Transform target;
        float timeSinceLastAttack=0;
    // Start is called before the first frame update
         public void Update()
        {
            timeSinceLastAttack+=Time.deltaTime;
            if(target == null)
                return ;
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            if(timeSinceLastAttack>timeBetweenAttacks )
            {
                GetComponent<Animator>().SetTrigger("Attack");
                timeSinceLastAttack=0;
                
            }
            
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(CombatTarget CombatTarget){
            GetComponent<ActionScheduler>().StartAction(this);
       target = CombatTarget.transform;
    }
    // Update is called once per frame
    public void cancel(){
        target=null;
    }
    void Hit(){
            Health healthComponent = target.GetComponent<Health>();
            healthComponent.TakeDamage(weaponDamage);
    }
   
}

}
