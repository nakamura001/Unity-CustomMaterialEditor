 using System.Collections.Generic;
 using UnityEngine;
 using UnityEditor;
 using System.Linq;
 
public class CustomMaterialInspector : MaterialEditor
{
	public override void OnInspectorGUI ()
	{
		// render the default inspector
		base.OnInspectorGUI ();
 
		// if we are not visible... return
		if (!isVisible)
			return;
 
		// get the current keywords from the material
		Material targetMat = target as Material;
		string[] keyWords = targetMat.shaderKeywords;
 
		// see if redify is set, then show a checkbox
		bool redify = keyWords.Contains ("REDIFY_ON");
		EditorGUI.BeginChangeCheck ();
		//  ここの記述が Inspector に反映される。今回は「Redify material」という名前のトグル(bool)のデータ
		redify = EditorGUILayout.Toggle ("Redify material", redify);
		if (EditorGUI.EndChangeCheck ()) {
			// if the checkbox is changed, reset the shader keywords
			//  チェックボックスの状態でShader内のキーワード (定数)を REDIFY_ON にするか REDIFY_OFF にするかを切り替える
			var keywords = new List<string> { redify ? "REDIFY_ON" : "REDIFY_OFF"};
			targetMat.shaderKeywords = keywords.ToArray ();
			EditorUtility.SetDirty (targetMat);
		}
	}
}
