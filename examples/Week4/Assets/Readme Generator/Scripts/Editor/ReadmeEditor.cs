using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Reflection;

[CustomEditor(typeof(Readme))]
[InitializeOnLoad]
public class ReadmeEditor : Editor {
	
	static string kShowedReadmeSessionStateName = "ReadmeEditor.showedReadme";
	
	static float kSpace = 16f;
	
	static ReadmeEditor()
	{
		EditorApplication.delayCall += SelectReadmeAutomatically;
	}
	
	static void SelectReadmeAutomatically()
	{
		if (!SessionState.GetBool(kShowedReadmeSessionStateName, false ))
		{
			var readme = SelectReadme();
			SessionState.SetBool(kShowedReadmeSessionStateName, true);
			
			if (readme && !readme.loadedLayout)
			{
				LoadLayout();
				readme.loadedLayout = true;
			}
		} 
	}
	
	static void LoadLayout()
	{
		var assembly = typeof(EditorApplication).Assembly; 
		var windowLayoutType = assembly.GetType("UnityEditor.WindowLayout", true);
		var method = windowLayoutType.GetMethod("LoadWindowLayout", BindingFlags.Public | BindingFlags.Static);
		method.Invoke(null, new object[]{Path.Combine(Application.dataPath, "TutorialInfo/Layout.wlt"), false});
	}
	
	[MenuItem("Tutorial/Show Tutorial Instructions")]
	static Readme SelectReadme() 
	{
		var ids = AssetDatabase.FindAssets("Readme t:Readme");
		if (ids.Length == 1)
		{
			var readmeObject = AssetDatabase.LoadMainAssetAtPath(AssetDatabase.GUIDToAssetPath(ids[0]));
			
			Selection.objects = new UnityEngine.Object[]{readmeObject};
			
			return (Readme)readmeObject;
		}
		else
		{
			Debug.Log("Couldn't find a readme");
			return null;
		}
	}
	
	protected override void OnHeaderGUI()
	{
		var readme = (Readme)target;
		Init();
		
		GUILayout.BeginVertical("In BigTitle");
		{
			GUILayout.Label(readme.title, TitleStyle);
			GUILayout.Label(readme.subtitle, SubtitleStyle);
		}
		GUILayout.EndVertical();
	}
	
	public override void OnInspectorGUI()
	{
		var readme = (Readme)target;
		Init();
		
		foreach (var section in readme.sections)
		{
			if (!string.IsNullOrEmpty(section.heading))
			{
				GUILayout.Label(section.heading, HeadingStyle);
			}
			if (!string.IsNullOrEmpty(section.text))
			{
				GUILayout.Label(section.text, BodyStyle);
			}
			GUILayout.Space(kSpace);
		}
	}
	
	
	bool m_Initialized;
	
	GUIStyle TitleStyle { get { return m_TitleStyle; } }
	[SerializeField] GUIStyle m_TitleStyle;

	GUIStyle SubtitleStyle { get { return m_SubtitleStyle; } }
	[SerializeField] GUIStyle m_SubtitleStyle;

	GUIStyle HeadingStyle { get { return m_HeadingStyle; } }
	[SerializeField] GUIStyle m_HeadingStyle;
	
	GUIStyle BodyStyle { get { return m_BodyStyle; } }
	[SerializeField] GUIStyle m_BodyStyle;
	
	void Init()
	{
		if (m_Initialized)
			return;
		m_BodyStyle = new GUIStyle(EditorStyles.label);
		m_BodyStyle.wordWrap = true;
		m_BodyStyle.fontSize = 14;
		
		m_TitleStyle = new GUIStyle(m_BodyStyle);
		m_TitleStyle.fontSize = 26;

		m_SubtitleStyle = new GUIStyle(m_BodyStyle);
		m_SubtitleStyle.fontSize = 23;
		m_SubtitleStyle.padding = new RectOffset(15, 0, 6, 2);

		m_HeadingStyle = new GUIStyle(m_BodyStyle);
		m_HeadingStyle.fontSize = 18 ;
		
		m_Initialized = true;
	}
}

