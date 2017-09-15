using UnityEngine;

namespace BeatThat
{
	/// <summary>
	/// Clamp a value that will then be used to drive another HasFloat.
	/// 
	/// Like other IDrive<HasFloat> components, can be chained, e.g. CurveValue -> ClampValue -> FloatProperty.
	/// Obviously important for setters to use the back end of the chain.
	/// 
	/// Example usage: 
	/// 
	/// The arms of a CameraGizmo fade out as their direction approaches parallel to camera forward.
	/// So a camera arm has an alpha 'value' property that is driven by camera rotation.
	/// In addition, the entire CameraGizmo may be set to fade out and hide.
	/// 
	/// So CameraGizmo arms can use a ClampValue to manage alpha: camera direction drives 'value' and show/hide fade transitions drive 'max'
	/// </summary>
	public class ClampValue : ProxiesFloat
	{
		public float m_min = 0f;
		public float m_max = 1f;

		override public void UpdateDisplay()
		{
			UpdateDriven();
		}

		private float lastDrivenValue { get; set; }

		private void UpdateDriven(bool force = false)
		{
			if(m_driven == null) {
				return;
			}

			var v = Mathf.Clamp(m_value, m_min, m_max);

			if(!force && Mathf.Approximately(v, this.lastDrivenValue)) {
				return;
			}

			this.lastDrivenValue = v;
			this.driven.value = v;
		}

		void Start()
		{
			UpdateDriven(true);
		}
	}

//	public class ClampValue : HasFloat, IDrive<HasFloat>
//	{
//		public HasFloat m_driven;
//		public float m_value;
//		public float m_min = 0f;
//		public float m_max = 1f;
//
//		public HasFloat driven 
//		{ 
//			get { 
//				if(m_driven == null) {
//					using(var hasFloats = ListPool<HasFloat>.Get()) {
//						GetComponents<HasFloat>(hasFloats);
//						foreach(var hf in hasFloats) {
//							if(hf == this) {
//								continue;
//							}
//							m_driven = hf;
//							break;
//						}
//					}
//				}
//				return m_driven;
//			}
//		}
//
//		public override bool sendsValueObjChanged { get { return false; } }
//
//		public object GetDrivenObject() { return this.driven; }
//
//		// Analysis disable ConvertToAutoProperty
//		override public float value { get { return m_value; } set { m_value = value; } }
//		// Analysis restore ConvertToAutoProperty
//
//
//		private float lastDrivenValue { get; set; }
//
//		private void UpdateDriver(bool force = false)
//		{
//			var v = Mathf.Clamp(m_value, m_min, m_max);
//
//			if(!force && Mathf.Approximately(v, this.lastDrivenValue)) {
//				return;
//			}
//
//			this.lastDrivenValue = v;
//			this.driven.value = v;
//		}
//
//		void Start()
//		{
//			UpdateDriver(true);
//		}
//
//		void LateUpdate()
//		{
//			UpdateDriver();
//		}
//	}
}
