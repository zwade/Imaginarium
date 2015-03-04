using UnityEngine;
using System.Collections;
using System.Linq;

public struct Complex {
	float real, imag;
	public Complex(float real, float imag) {
		this.real = real;
		this.imag = imag;
	}
	public static Complex FromPolar(float r, float phi) {
		return new Complex(r * Mathf.Cos(phi), r * Mathf.Sin(phi));
	}
	public float Phase {
		get {
			return Mathf.Atan2(imag, real);
		}
	}
	public float Mag {
		get {
			return Mathf.Sqrt(real * real + imag * imag);
		}
	}
	public static Complex operator +(Complex x, Complex y) {
		return new Complex(x.real + y.real, x.imag + y.imag);
	}
	public static Complex operator -(Complex x, Complex y) {
		return new Complex(x.real - y.real, x.imag - y.imag);
	}
	public static Complex operator *(Complex x, Complex y) {
		return new Complex(x.real * y.real - x.imag * y.imag, x.imag * y.real + x.real * y.imag);
	}
	public static Complex operator /(Complex x, Complex y) {
		return new Complex((x.real * y.real + x.imag * y.imag) / (y.real * y.real + y.imag * y.imag), (x.imag * y.real - x.real * y.imag) / (y.real * y.real + y.imag * y.imag));
	}
	public static Complex operator *(Complex x, float y) {
		return new Complex(y * x.real, y * x.imag);
	}
	public static Complex operator /(Complex x, float y) {
		return x * (1 / y);
	}
	public static bool operator ==(Complex x, Complex y) {
		return x.real == y.real && x.imag == y.imag; // floating point errors ayy lmao
	}
	public static bool operator !=(Complex x, Complex y) {
		return !(x == y);
	}
	// Exponentiation is quite involved--do we really expect a player to do it by hand?
	// public static Complex operator ^(Complex x, Complex y) { ... }
	public Complex[] Roots(int n) {
		float nthRootOfMagnitude = Mathf.Pow(Mag, 1.0f / n), phase = Phase;
		return Enumerable.Range(0, n)
				.Select(k => FromPolar(
					nthRootOfMagnitude,
					phase / n + k * 2 * Mathf.PI / n))
				.ToArray();
	}
	public override string ToString() {
		return real + " + " + imag + "i";
	}
}