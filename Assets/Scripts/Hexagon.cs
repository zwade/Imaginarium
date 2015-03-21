using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Hexagon : MonoBehaviour {
	private const int X_OFFSET = 79;
	private const int Y_OFFSET = 90;
	private const float DURATION = 2F;
	private const float MIN_DURATION = 1F;

	private List<Image> hexagons;
	private List<float> delays;
	private List<float> times;
	private GameObject proto;
	private CanvasGroup group;
	private int fade = 1;

	// Use this for initialization
	void Awake () {
		hexagons = new List<Image>();
		delays = new List<float>();
		times = new List<float>();
		proto = transform.GetChild(0).gameObject;
		group = transform.GetComponent<CanvasGroup>();
		group.alpha = 0;
		Initialize(proto);
		// Generate the first column
		Generate(proto.transform.localPosition.x, proto.transform.localPosition.y - Y_OFFSET);
		// Generate subsequent columns
		bool offset = true;
		for (float x = proto.transform.localPosition.x + X_OFFSET; x + X_OFFSET < 550; x += X_OFFSET, offset = !offset) {
			Generate(x, offset ? proto.transform.localPosition.y + Y_OFFSET / 2 : proto.transform.localPosition.y);
		}
	}

	void Generate(float x, float y) {
		for (GameObject g; y > -300; y -= Y_OFFSET) {
			g = Instantiate(proto);
			g.transform.SetParent(transform);
			g.transform.localPosition = new Vector3(x, y, proto.transform.localPosition.z);
			g.transform.localScale = proto.transform.localScale;
			Initialize(g);
		}
	}

	void Initialize(GameObject g) {
		Image i = g.GetComponent<Image>();
		delays.Add(Random.value * (DURATION - MIN_DURATION) + MIN_DURATION);
		hexagons.Add(i);
		if (Random.value > 0.5) {
			// Start visible
			times.Add(Random.value * (DURATION - MIN_DURATION) + MIN_DURATION);
			i.color = new Color(255, 255, 255, Mathf.Lerp(0, 1, Mathf.Sin(Mathf.PI * times[times.Count - 1] / 2 / delays[delays.Count - 1])));
		} else {
			// Start delayed
			times.Add(0F);
			i.color = new Color(255, 255, 255, 0F);
		}
	}

	// Update is called once per frame
	void Update () {
		if (fade != 0) {
			group.alpha += fade * Time.deltaTime / 2;
			if (group.alpha <= 0 || group.alpha >= 1) {
				fade = 0;
			}
		}
		if (group.alpha >= 0) {
			for (int i = 0; i < hexagons.Count; i++) {
				times[i] += Time.deltaTime;
				if (hexagons[i].color.a > 0) {
					hexagons[i].color = new Color(255, 255, 255, Mathf.Lerp(0, 1, Mathf.Sin(Mathf.PI * times[i] / 2 / delays[i])));
					if (hexagons[i].color.a == 0) {
						times[i] = 0F;
					}
				} else if (times[i] >= delays[i]) {
					times[i] = Time.deltaTime;
					hexagons[i].color = new Color(255, 255, 255, Mathf.Lerp(0, 1, Mathf.Sin(Mathf.PI * times[i] / 2 / delays[i])));
				}
			}
		}
	}

	public void AnimateAlpha() {
		fade = group.alpha >= 0.5 ? -1 : 1;
	}
}
