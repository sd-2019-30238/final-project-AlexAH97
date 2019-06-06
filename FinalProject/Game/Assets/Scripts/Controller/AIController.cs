using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.COntroll{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
    

    // Update is called once per frame
    void Update()
        {
            
            if(DistanceToPlayer()<chaseDistance)
            {
                print("Should chase");
            }
        }

        private float DistanceToPlayer()
        {
            GameObject player = GameObject.FindWithTag("Player");
            print(player.name);
            return Vector3.Distance(player.transform.position, transform.position);

        }
    }

}
