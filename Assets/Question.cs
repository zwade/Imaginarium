using UnityEngine;
using System.Collections;

public delegate Complex Operation(Complex x, Complex y);

public struct Question {
	Complex x, ans;
	Operation op;
	public Question(Complex x, Complex ans, Operation op) {
		this.x = x;
		this.ans = ans;
		this.op = op;
	}
	public bool Answer(Complex y) {
		return op(x, y) == ans;
	}
}