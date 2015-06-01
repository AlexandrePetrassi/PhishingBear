using UnityEngine;
using System.Collections;
using TecnoCop.PlayerControl;
using UnityEngine.UI;

namespace TecnoCop{
	namespace Effects{
		public class TransparentParticle : FadeParticle {

			public float transparencyFade;
			public float pmin, pmax;

			void Update(){
				spriteRenderer.color = spriteRenderer.color - new Color(0,0,0,transparencyFade);
				/*foreach(SpriteRenderer rend in GetComponentsInChildren<SpriteRenderer>())
					rend.color = new Color(rend.color.r,rend.color.g,rend.color.b,spriteRenderer.color.a);
				foreach(Image rend in GetComponentsInChildren<Image>())
					rend.material.color = new Color(rend.material.color.r,rend.material.color.g,rend.material.color.b,spriteRenderer.color.a);*/

				if(spriteRenderer.color.a <= 0) Destroy(gameObject);
			}

			/*void Start(){
				AudioSource audioS = GetComponent<AudioSource>();
				audioS.pitch = Random.Range(pmin,pmax);
				//audioS.volume = 10/Vector3.Distance(transform.position,Player.player.transform.position);
				audioS.Play();
			}*/
		}
	}
}
