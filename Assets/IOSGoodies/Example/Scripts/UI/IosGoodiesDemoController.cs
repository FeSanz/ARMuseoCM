using JetBrains.Annotations;

namespace DeadMosquito.IosGoodies.Example
{
	using System.Collections.Generic;
	using UnityEngine;

	public class IosGoodiesDemoController : MonoBehaviour
	{
		void FindPanel(ref GameObject panel, string name)
		{
			if (panel == null)
			{
				panel = FindObject(gameObject, name);
			}
		}

		public static GameObject FindObject(GameObject parent, string name)
		{
			var trs = parent.GetComponentsInChildren<Transform>(true);
			foreach (var t in trs)
			{
				if (t.name == name)
				{
					return t.gameObject;
				}
			}

			return null;
		}
#if UNITY_IOS
		GameObject mainMenuPanel;

		GameObject mapsPanel;
		GameObject uiPanel;
		GameObject sharePanel;
		GameObject openAppsPanel;
		GameObject hardwarePanel;
		GameObject infoPanel;
		GameObject calendarPanel;

		List<GameObject> _windows;

		void Awake()
		{
			InitWindows();
		}

		void InitWindows()
		{
			FindPanel(ref mainMenuPanel, "MainMenuPanel");
			FindPanel(ref mapsPanel, "MapsPanel");
			FindPanel(ref uiPanel, "UiPanel");
			FindPanel(ref sharePanel, "SharingPanel");
			FindPanel(ref openAppsPanel, "OpenAppsPanel");
			FindPanel(ref hardwarePanel, "HardwarePanel");
			FindPanel(ref infoPanel, "InfoPanel");
			FindPanel(ref calendarPanel, "CalendarPanel");

			_windows = new List<GameObject>
			{
				mainMenuPanel,
				mapsPanel,
				uiPanel,
				sharePanel,
				openAppsPanel,
				hardwarePanel,
				infoPanel, 
				calendarPanel
			};
			_windows.ForEach(w => w.SetActive(false));
			mainMenuPanel.SetActive(true);
		}

		[UsedImplicitly]
		public void OnMapsPanel()
		{
			mapsPanel.SetActive(true);
		}

		[UsedImplicitly]
		public void OnUiPanel()
		{
			uiPanel.SetActive(true);
		}

		[UsedImplicitly]
		public void OnSharePanel()
		{
			sharePanel.SetActive(true);
		}

		[UsedImplicitly]
		public void OnOpenAppsPanel()
		{
			openAppsPanel.SetActive(true);
		}

		[UsedImplicitly]
		public void OnOpenHardwarePanel()
		{
			hardwarePanel.SetActive(true);
		}

		[UsedImplicitly]
		public void OnOpenInfoPanel()
		{
			infoPanel.SetActive(true);
		}
		
		[UsedImplicitly]
		public void OnOpenCalendarPanel()
		{
			calendarPanel.SetActive(true);
		}
#endif
	}
}