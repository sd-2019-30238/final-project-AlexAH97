using System.Collections;
using System.Collections.Generic;

using RPG.Core;
using UnityEngine;
using UnityEngine.AI;
namespace RPG.Movement{
        public class Mover : MonoBehaviour,IAction
    {
    
   NavMeshAgent NavMeshAgent;
   private void Start() {
       NavMeshAgent=GetComponent<NavMeshAgent>();
   }
    void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
         //   MoveToCusrsor();
       // }
       UpdateAnimator();
      
       
    }
    private void UpdateAnimator(){
        Vector3 velocity=NavMeshAgent.velocity;
        Vector3 localVelocity=transform.InverseTransformDirection(velocity);
        float speed=localVelocity.z;
        GetComponent<Animator>().SetFloat("ForwardSpeed",speed);
    }
    private void MoveToCusrsor(){
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit=Physics.Raycast(ray,out hit);
        if(hasHit)
        {
            MoveTo(hit.point);
        }
    }
    public void cancel(){
        NavMeshAgent.isStopped=true;
    
    }
   
    public void MoveTo(Vector3 destination)
    {
        NavMeshAgent.destination = destination;
        NavMeshAgent.isStopped=false;
    }
    public void StartMoveAction(Vector3 destination)
    {
        GetComponent<ActionScheduler>().StartAction(this);
       
        MoveTo(destination);
    }
}

}
