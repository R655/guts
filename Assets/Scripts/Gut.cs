using System;	
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class Gut
	{
		public enum State
		{
			SleepOutside,
			Stay,
			Walk,
			Eating,
			Mating,
			Hunting,
			Stalking,
			Dead,
			InHome
		};
		public enum Param
		{
			Age,
			Starve,
			Fatique,
			Health
		};



		public Dictionary<Param, float> param = 
			new Dictionary<Param, float>()
			{
				{Param.Health, 0.5f},
				{Param.Age, 0.5f},
				{Param.Starve, 0.3f},
				{Param.Fatique, 0.1f}	
			};

		public Transform gutPrefab;
		public State state = State.Stay;
		public Transform gameObject;



		public Gut (int i, int j)
		{
			gameObject = 
				(Transform)GameObject.Instantiate(
					gutPrefab, 
					new Vector3(
						0f,
						0f,
						0f), 
					Quaternion.identity);
			;
		}

		public void Death()
		{
			state = State.Dead;
		}
	}
}

