﻿using UnityEngine;
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
			float at = Mathf.Atan2(imag, real);
			if (float.IsNaN (at)) {
				return 0;
			}
			while (at < 0) {
				at += 2*Mathf.PI;
			}
			return at;
		}
		set {
			this.real = this.Mag*Mathf.Cos(value) ;
			this.imag = this.Mag*Mathf.Sin (value);
		}
	}
	public float Mag {
		get {
			float o = Mathf.Sqrt(real * real + imag * imag);
			return float.IsNaN (o) ? 0 : o;
		}
		set {
			float oldMag = this.Mag;
			this.real = value/oldMag*this.real;
			this.imag = value/oldMag*this.imag;
		}

	}

	public Vector3 toVector3 {
		get {
			return new Vector3(real*10, 0, imag*10);
		}
	}
	public Vector3 toVector2 {
		get {
			return new Vector2(real*10,imag*10);
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
		Complex tmp = Complex.FromPolar (x.Mag,x.Phase+t);
		return tmp;
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