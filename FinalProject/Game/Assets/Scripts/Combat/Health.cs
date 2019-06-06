using UnityEngine;
namespace RPG.Combat{
    public class Health:MonoBehaviour
    {
        [SerializeField]float health=15f;
        bool isDead = false;
        public void TakeDamage(float damage)
        {
            health=Mathf.Max(health-damage,0);
            if(health<0)
            {
                Die();
            }
            print(health);
        }

        private void Die()
        {
            if(isDead)
             return;
             isDead=true;
            GetComponent<Animator>().SetTrigger("Die");
        }

        public float GetHealth(){return health;}
    }
}