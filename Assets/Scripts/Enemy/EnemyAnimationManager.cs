using UnityEngine;
using System.Collections;

namespace TecnoCop{
	namespace Enemy{
		public class EnemyAnimationManager : AnimationManager {
			
			protected override void setAnimationFlags(){
				animator.SetFloat("SpeedX",(int)(Mathf.Abs(ribo.velocity.x)));
			}

			protected override void setLookingDirection ()
			{
				if(!collision.feet.isColliding || collision.front.isColliding)
					transform.localScale =  new Vector3(transform.localScale.x *-1,transform.localScale.y,transform.localScale.z);

			}
		}
	}
}

