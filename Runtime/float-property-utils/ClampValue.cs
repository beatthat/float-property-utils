using UnityEngine;

namespace BeatThat.Properties
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
            if(m_driveProperty == null) {
				return;
			}

			var v = Mathf.Clamp(m_value, m_min, m_max);

			if(!force && Mathf.Approximately(v, this.lastDrivenValue)) {
				return;
			}

			this.lastDrivenValue = v;
			this.driven.value = v;
		}

        override protected void Start()
		{
            base.Start();
			UpdateDriven(true);
		}
	}

}
