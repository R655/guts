using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class GutLogics : MonoBehaviour 
	{
		public Transform gutPrefab;

		public enum MapObjects
		{
			Ground,
			Cantgo
		}

		public MapObjects[,] map;

		public Dictionary<Gut.Param, Dictionary<Gut.State, float>> speeds = 
		new Dictionary<Gut.Param, Dictionary<Gut.State, float>>()
		{
			{
				Gut.Param.Starve,
				new Dictionary<Gut.State, float>() 
				{
					{Gut.State.Sleep, -0.1f},
					{Gut.State.Walk, -0.5f},
					{Gut.State.Stay, -0.3f},
					{Gut.State.Eating, 0.3f}
				}
			},
			{
				Gut.Param.Age,
				new Dictionary<Gut.State, float>() 
				{
					{Gut.State.Sleep, 0.3f},
					{Gut.State.Walk, 0.3f},
					{Gut.State.Stay, 0.3f},
					{Gut.State.Eating, 0.3f}
				}
			},
			{
				Gut.Param.Fatique,
				new Dictionary<Gut.State, float>() 
				{
					{Gut.State.Sleep, 0.5f},
					{Gut.State.Walk, -0.5f},
					{Gut.State.Stay, 0.1f},
					{Gut.State.Eating, 0.1f}
				}
			}
		};
		public Dictionary<Gut.Param, float> maximums = 
		new Dictionary<Gut.Param, float>()
		{
			{Gut.Param.Age, 50f},
			{Gut.Param.Fatique, 50f},
			{Gut.Param.Starve, 50f},
			{Gut.Param.Health, 50f},
		};

		public Dictionary<Gut.Param, float> minimums = 
		new Dictionary<Gut.Param, float>()
		{
			{Gut.Param.Age, 0f},
			{Gut.Param.Fatique, 0f},
			{Gut.Param.Starve, 0f},
			{Gut.Param.Health, 0f},
		};

		LinkedList<Gut> guts;

		void Start () {
			guts = new LinkedList<Gut>();
		}

		void Update () {
			foreach(Gut gut in guts)
			{
				foreach(var par in gut.param)
				{
					gut.param[par.Key] += speeds[par.Key][gut.state]*Time.deltaTime;

					if(par.Value > maximums[par.Key])
						gut.param[par.Key] = maximums[par.Key];

					if(par.Value < minimums[par.Key])
					{
						gut.param[par.Key] = minimums[par.Key];
						gut.Death();
						guts.Remove(gut);
					}
				}
			}
		}

		void GoTo(int i, int j)
		{

		}


	}
}
