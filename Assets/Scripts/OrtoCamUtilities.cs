using System;
using UnityEngine;

namespace Utiles
{
	public class OrtoCamUtilities
	{
		public OrtoCamUtilities ()
		{
		}

		public static float CamWidth(Camera cam) {
			if (cam.orthographic)
				return cam.orthographicSize * cam.aspect * 2;
			else
				return -1f;
		}

		public static float CamHeight(Camera cam) {
			if (cam.orthographic)
				return cam.orthographicSize * 2;
			else
				return -1f;
		}

		public static float CamSemiWidth(Camera cam) {
			if (cam.orthographic)
				return cam.orthographicSize * cam.aspect;
			else
				return -1f;
		}
		
		public static float CamSemiHeight(Camera cam) {
			if (cam.orthographic)
				return cam.orthographicSize;
			else
				return -1f;
		}

		public static void MatchSize(Camera cam, Renderer rend, bool x, bool y) {
			if (cam.orthographic) {
				float camWidth = cam.orthographicSize * cam.aspect * 2;
				float camHeight = cam.orthographicSize * 2;
				float width = rend.bounds.size.x;
				float height = rend.bounds.size.y;

				if (x) {
					float factor = camWidth / width;

					Vector3 scale = rend.transform.localScale;
					scale.x *= factor;

					rend.transform.localScale = scale;
				}

				if (y) {
					float factor = camHeight / height;
					
					Vector3 scale = rend.transform.localScale;
					scale.y *= factor;
					
					rend.transform.localScale = scale;
				}
			}
		}

		public static void MatchHegiht(Camera cam, Renderer rend, bool keepAspect) {
			if (cam.orthographic) {
				float camHeight = cam.orthographicSize * 2;
				float height = rend.bounds.size.y;
				
				float factor = camHeight / height;
				
				Vector3 scale = rend.transform.localScale;
				if (keepAspect)
					scale *= factor;
				else
					scale.y *= factor;
				
				rend.transform.localScale = scale;
			}
		}

		public static void MatchWidth(Camera cam, Renderer rend, bool keepAspect) {
			if (cam.orthographic) {
				float camWidth = cam.orthographicSize * cam.aspect * 2;
				float width = rend.bounds.size.x;
				
				float factor = camWidth / width;
					
				Vector3 scale = rend.transform.localScale;
				if (keepAspect)
					scale *= factor;
				else
					scale.x *= factor;
					
				rend.transform.localScale = scale;
			}
		}

		public static void MatchLeftEdge(Camera cam, Renderer rend) {
			if (cam.orthographic) {
				float semiWidth = rend.bounds.size.x * 0.5f;
				float camLeft = cam.orthographicSize * -cam.aspect + cam.transform.position.x;

				Vector3 pos = rend.transform.position;
				pos.x = camLeft + semiWidth;

				rend.transform.position = pos;
			}
		}

		public static void MatchRightEdge(Camera cam, Renderer rend) {
			if (cam.orthographic) {
				float semiWidth = rend.bounds.size.x * 0.5f;
				float camRight = cam.orthographicSize * cam.aspect + cam.transform.position.x;
				
				Vector3 pos = rend.transform.position;
				pos.x = camRight - semiWidth;
				
				rend.transform.position = pos;
			}
		}

		public static void MatchTopEdge(Camera cam, Renderer rend) {
			if (cam.orthographic) {
				float semiHeight = rend.bounds.size.y * 0.5f;
				float camUp = cam.orthographicSize + cam.transform.position.y;
				
				Vector3 pos = rend.transform.position;
				pos.y = camUp - semiHeight;
				
				rend.transform.position = pos;
			}
		}

		public static void MatchBottomEdge(Camera cam, Renderer rend) {
			if (cam.orthographic) {
				float semiHeight = rend.bounds.size.y * 0.5f;
				float camBottom = cam.orthographicSize + cam.transform.position.y;
				
				Vector3 pos = rend.transform.position;
				pos.y = camBottom + semiHeight;
				
				rend.transform.position = pos;
			}
		}
	}
}

