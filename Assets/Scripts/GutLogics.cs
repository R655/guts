using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class GutLogics : MonoBehaviour 
	{
		public Transform gutPrefab;

		LinkedList<Gut> guts;

		void Start () {
			guts = new LinkedList<Gut>();
		}
		
		void Update () {
			foreach(Gut gut in guts)
			{

			}
			// golod
			// ustalost
		}
	}
}
