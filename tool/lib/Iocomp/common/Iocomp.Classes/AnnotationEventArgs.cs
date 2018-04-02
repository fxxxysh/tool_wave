using System;

namespace Iocomp.Classes
{
	public class AnnotationEventArgs : EventArgs
	{
		private AnnotationBase m_Annotation;

		public AnnotationBase Annotation => m_Annotation;

		public AnnotationEventArgs(AnnotationBase annotation)
		{
			m_Annotation = annotation;
		}
	}
}
