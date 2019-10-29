using UnityEngine;

namespace AI
{
    public class Attack : Node
    {

        [SerializeField]
        private float timeToShoot; //Time to change the state
        private float time =3 ; //current time

        public override void Execute()
        {
            if (targetAI.Rifle.Shooting ) //When the chacter is in shoot mode
            {
                if (targetAI.ControlMov.NavAgent.velocity.magnitude<1) //look when is moving
                {
                    targetAI.transform.LookAt(enemy.transform.position, Vector3.up);
                }


                if (time > timeToShoot) //Time to change mode
                {
                    targetAI.Rifle.StopShoot();
                    time = 0;
                }
                else {
                    time += Time.deltaTime*10;
                }

            }
            else {
                if (time > timeToShoot)//Time to change mode
                {
                    targetAI.Rifle.PrepareGun();
                    time = 0;
                }
                else
                {
                    time += Time.deltaTime * 10;
                }
            }          
        }
        
    }
}
