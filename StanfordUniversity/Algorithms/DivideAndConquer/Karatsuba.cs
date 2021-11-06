using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.DivideAndConquer {
    public class Karatsuba
        : List<int> {
        public Karatsuba(IEnumerable<int> data) 
            : base(data) { }

        public Karatsuba(string data)
            : base(Enumerable.Range(0, data.Length)
            .Select(i => int.Parse(data.Substring(i, 1)))) { }
        
        public static Karatsuba operator *(Karatsuba A, Karatsuba B) {
            if (A.Count == 1) return new Karatsuba((A[0] * B[0]).ToString());

            var n = Math.Max(A.Count, B.Count) >> 1;
            var a = new Karatsuba(A.GetRange(0, n));
            var b = new Karatsuba(A.GetRange(n, Math.Max(1, n)));
            var c = new Karatsuba(B.GetRange(0, n));
            var d = new Karatsuba(B.GetRange(n, Math.Max(1, n)));

            return ((a * c) << (n << 1)) + ((a * d) << n) + ((b * c) << n) + (b * d);
        }

        public static Karatsuba operator <<(Karatsuba A, int n) {
            A.AddRange(new int[n]);
            return A;
        }

        public static Karatsuba operator +(Karatsuba A, Karatsuba B) {
            var output = new Stack<int>();
            for (int i = A.Count, j = B.Count, c = 0; c != 0 || i != 0 || j != 0; c /= 10) {
                c += (i > 0 ? A[--i] : 0) + (j > 0 ? B[--j] : 0);
                output.Push(c % 10);
            }
            return new Karatsuba(output);
        }
    }
}

//public static Karatsuba operator -(Karatsuba A, Karatsuba B) {
//    var output = new Stack<int>();
//    for (int i = A.Count, j = B.Count, c = 0; i > 0 || j > 0; c = c < 10 ? 1 : 0) {
//        c = (i > 1 ? 10 + A[--i] : i > 0 ? A[--i] : 0) - (j > 0 ? B[--j] + c : c);
//        output.Push(c % 10);
//    }
//    return new Karatsuba(output);
//}