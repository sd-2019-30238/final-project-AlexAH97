using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Movement;
using UnityEngine;
namespace RPG.COntroll{
    public class PlayerController : MonoBehaviour
    {
    // Start is called before the first frame update
    private void MoveToCusrsor()
        {
           
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButtonDown(0))
                GetComponent<Mover>().MoveTo(hit.point);
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        public void Update()
        {
            if(InteractWithCombat())
                return;
            if(InteractWithMovement()){
             //   print("Nothing to do.");
            }
            
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits=Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit item in hits)
            {
                CombatTarget target=item.transform.GetComponent<CombatTarget>();
                if(target==null)
                    continue;
                if(Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                    
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButtonDown(0))
                    GetComponent<Mover>().StartMoveAction(hit.point);
                return true;
            }
            return false;
        }
    }

}
