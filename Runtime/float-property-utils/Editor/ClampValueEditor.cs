//using UnityEditor;
//using UnityEngine;
//
//namespace BeatThat
//{
//	[CustomEditor(typeof(ClampValue), true)]
////	[CanEditMultipleObjects]
//	public class ClampValueEditor : UnityEditor.Editor
//	{
//		public override void OnInspectorGUI()
//		{
//			EditorGUI.BeginChangeCheck ();
//
//			this.serializedObject.Update();
//		
//			var valueProp = this.serializedObject.FindProperty("m_value");
//			var updateDisplayOnEnableProp = this.serializedObject.FindProperty("m_updateDisplayOnEnable");
//			var applyChangesOnLateUpdate = this.serializedObject.FindProperty("m_applyChangesOnLateUpdate");
//
//			ProxiesFloatEditor.DrivenField(this);
//			valueProp.floatValue = EditorGUILayout.FloatField("value", valueProp.floatValue);
//			EditorGUILayout.PropertyField(updateDisplayOnEnableProp);
//			EditorGUILayout.PropertyField(applyChangesOnLateUpdate);
//
//			this.serializedObject.ApplyModifiedProperties();
//
//			if (EditorGUI.EndChangeCheck()) {
//				(this.target as DisplaysFloat).UpdateDisplay();
//			}
//
//		}
//
//		virtual protected void OnDisplaysFloatInspectorGUI() 
//		{
//			base.OnInspectorGUI();
//		}
//	}
//}