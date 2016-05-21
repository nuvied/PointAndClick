using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace HOL
{
	public class HOLSceneManager : MonoBehaviour
	{
		static HOLSceneManager instance;
		public ItemManager itemManager;
		public Canvas linkedCanvas;
		public static List<GameObject> itemObj = new List<GameObject> ();

		public List<HOL.Item> runtimeItems;

		public static HOLSceneManager i {
			get{ return instance; }

		}


		public void SetupItems ()
		{

		}

		void Awake ()
		{
			instance = this;
			runtimeItems = itemManager.Items;
			foreach (HOL.Item itm in runtimeItems)
				itm.picked = false;
			



		}

		void Start ()
		{
			
		}


		void Update ()
		{
		
		}

		public void ItemPicked (string name)
		{
			for (int i = 0; i < runtimeItems.Count; i++)
			{
				if (runtimeItems [i].name == name)
				{
					runtimeItems [i].picked = true;
					return;
				}
			}
		}

		//		public GameObject ItemPicked (string name)
		//		{
		//
		//		}



	}
}
