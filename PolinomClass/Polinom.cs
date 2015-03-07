using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolinomClass
{
    public class Polinom
    {
        private float[] factor;
        public Polinom(params float[] arrayFactor)
        {
            factor = arrayFactor;
        }
        
        public float this[int degree]
        {
            get
            {
                return factor[degree];
            }
            set
            {
                factor[degree] = value;
            }
        }

        public static Polinom operator +(Polinom polinom1,Polinom polinom2)
        {
            Polinom result = new Polinom(new float[Math.Max(polinom1.factor.Length, polinom2.factor.Length)]);
            if(polinom1.factor.Length>=polinom2.factor.Length)
            {
                for (int i = 0; i < polinom2.factor.Length; i++)
                    result.factor[i] = polinom1.factor[i] + polinom2.factor[i];
                for (int j = polinom2.factor.Length; j < polinom1.factor.Length; j++)
                    result.factor[j] = polinom1.factor[j];
            }
            else
            {
                for (int i = 0; i < polinom1.factor.Length; i++)
                    result.factor[i] = polinom1.factor[i] + polinom2.factor[i];
                for (int i = polinom1.factor.Length + 1; i < polinom2.factor.Length; i++)
                    result.factor[i] = polinom2.factor[i];
            }
            return result;
        }

        public static Polinom operator -(Polinom polinom1,Polinom polinom2)
        {
            for (int i = 0; i < polinom2.factor.Length; i++)
                polinom2.factor[i] *= (-1);
            return polinom1 + polinom2;
        }

        public static Polinom operator *(Polinom polinom1,Polinom polinom2)
        {
            Polinom result = new Polinom(new float[polinom1.factor.Length + polinom2.factor.Length - 1]);
            for (int i = 0; i < polinom1.factor.Length; i++)
                for (int j = 0; j < polinom2.factor.Length; j++)
                    result.factor[i+j] += polinom1.factor[i] * polinom2.factor[j];
            return result;
        }

        public static Polinom operator / (Polinom polinom1,Polinom polinom2)
        {
            Polinom result;
            float[] dividend = polinom1.factor;
            if (polinom1.factor.Length >= polinom2.factor.Length)
            {
                if (polinom1.factor.Last() == 0|| polinom2.factor.Last()==0) throw new ArithmeticException("Invalid data of polinom");
                result = new Polinom(new float[polinom1.factor.Length - polinom2.factor.Length + 1]);
                for (int i = 0; i < result.factor.Length; i++)
                {
                    float tempFactor = dividend[dividend.Length - i - 1] / polinom2.factor.Last();
                    result.factor[result.factor.Length - i - 1] = tempFactor;
                    for (int j = 0; j < polinom2.factor.Length; j++)
                    {
                        dividend[dividend.Length - i - j - 1] -= tempFactor * polinom2.factor[polinom2.factor.Length - j - 1];
                    }
                }
            }
            else result = null;
            return result;
        }

        public static bool operator==(Polinom polinom1,Polinom polinom2)
        {
            if(polinom1.factor.Length==polinom2.factor.Length)
            {
                for(int i=0;i<polinom1.factor.Length;i++)
                    if(polinom1.factor[i]!=polinom2.factor[i]) return false;
                return true;               
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;
            return this == obj;
        }
        public static bool operator !=(Polinom polinom1, Polinom polinom2)
        {
            if ((polinom1 == polinom2)) return false;
            return true;
        }

        public override string ToString()
        {
            string polinomStr=this.factor.Last()+"*x^"+(this.factor.Length-1);
            for(int i=this.factor.Length-2;i>=0;i--)
                polinomStr+="+"+this.factor[i]+"*x^"+i;
            return polinomStr;
        }
    }
}
