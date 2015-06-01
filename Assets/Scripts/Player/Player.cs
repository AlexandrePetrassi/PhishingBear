using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TecnoCop{
	namespace PlayerControl{
		/// <summary>
		/// Player.
		/// Classe responsavel por gerenciar o jogador.
		/// Chama o metodo update de todos os playerTriggers associados a ele
		/// </summary>
		public class Player : ModuleManager, IUpdatable{

			static public Direction bornPosition = Direction.left;
			private List<PlayerTrigger> myUpdateables = new List<PlayerTrigger>();
			public static int lives = 3;

			/// <summary>
			/// Awake this instance.
			/// </summary>
			void Awake () {
				myPlayer = this;
				GetComponents<PlayerTrigger>(myUpdateables);
				myUpdateables.Reverse(); // Isso eh temporario. Implementar algoritmo para ordenar a lista de forma correta
				DontDestroyOnLoad(gameObject);
				//FindObjectOfType<LifeDisplayer>().refresh();
			}
			
			/// <summary>
			/// Update this instance.
			/// </summary>
			public void update () {
				foreach(PlayerTrigger updateable in myUpdateables)
					updateable.update();
			}

			//----------------------------------//

			// triggerables
			static private Player           myPlayer;
			static private Move             myMove;
			static private Jump             myJump;

			static public Player player{
				get{
					return myPlayer;
				}
				set{
					if(myPlayer!=null){
						Destroy(myPlayer.gameObject);
					}
					myPlayer = value;
				}
			}
			
			static public Jump jump{
				get{
					if(myJump == null)
						myJump = player.GetComponent<Jump>();
					return myJump;
				}
				set{
					myJump = value;
				}
			}

			static bool myIsPaused = false;
			public static bool isPaused{
				get{
					return myIsPaused;
				}
				set{
					if(value){
						Time.timeScale = 0;
						myIsPaused = true;
					}else{
						Time.timeScale = 1;
						myIsPaused = false;
					}
				}
			}

			public int myScore = 0;
			public int score{
				get{
					return myScore;
				}
				set{
					myScore = value;
					FindObjectOfType<LifeDisplayer>().score.text = value.ToString();
					if(value >= FindObjectOfType<ResultDisplayer>().pointsToWin) FindObjectOfType<LifeDisplayer>().callResults();
				}
			}

		}
	}
	public enum Direction{
		left,
		right,
		up,
		down
	}
}