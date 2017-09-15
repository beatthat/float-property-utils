using UnityEngine;

namespace BeatThat
{
	/// <summary>
	/// Apply a curve to a HasFloat.
	/// 
	/// Like other IDrive<HasFloat> components, can be chained, e.g. CurveValue -> ClampValue -> FloatProperty.
	/// Obviously important for setters to use the back end of the chain.
	/// </summary>
	public class CurveValue : ProxiesFloat
	{
		public AnimationCurve m_curve;
		public float m_curvedValue;
		public bool m_disableCurve;

		override public void UpdateDisplay()
		{
			if(m_driven == null) {
				return;
			}
			m_curvedValue = m_curve.Evaluate(this.value);
			m_driven.value = (m_disableCurve)? this.value: m_curvedValue;
		}

		override protected void Reset()
		{
			base.Reset();
			if(m_curve == null || m_curve.length == 0) {
				m_curve = AnimationCurve.Linear(0, 0, 1, 1);
			}
		}
	}
}
