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

	public Vector3 toVector3 {
		get {
			return new Vector3(real*10, 0, imag*10);
		}
	}
	public static Complex c1 () {
		return new Complex(1,0);
	}
	public static Complex cI () {
		return new Complex(0,1);
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
	public static Complex operator ^ (Complex x, float y) {
		return Complex.FromPolar(Mathf.Pow (x.Mag,y),x.Phase*y) ;
	}
	//rotate
	public static Complex operator & (Complex x, float t) {
		return Complex.FromPolar (x.Mag,x.Phase+t);
	}
	//extend
	public static Complex operator | (Complex x, float r) {
		return Complex.FromPolar (x.Mag+r,x.Phase);
	}
	public static bool operator ==(Complex x, Complex y) {
		return x.real == y.real && x.imag == y.imag; // floating point errors ayy lmao
	}
	public static bool operator !=(Complex x, Complex y) {
		return !(x == y);
	}
	public override bool Equals(object obj) {
		return this == (Complex) obj;
	}
	public override int GetHashCode() {
		return (real.GetHashCode() + imag).GetHashCode(); // "nice and clean"
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
		if (Mathf.Abs(imag) <= 0.01) {
			return (Mathf.Round (real*10)/10).ToString ();
		} else if (Mathf.Abs(real) <= 0.01) {
			return (Mathf.Round (imag*10)/10) + "i";
		} 
		return Mathf.Round(real*10)/10 + " + " + Mathf.Round(imag*100)/100 + "i";
	}
}