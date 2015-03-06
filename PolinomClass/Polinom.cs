using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolinomClass
{
    public class Polinom
    {
        int degree;
        float[] arrayFactor;
        public Polinom(float[] arrayFactor)
        {
            this.arrayFactor = arrayFactor;
            if (arrayFactor == null) this.degree = 0;
            else this.degree = arrayFactor.Length;
        }

        public float[] ArrayFactor
        {
            get
            {
                return arrayFactor;
            }
        }
        public string PrintPolinom()
        {
            string printStr=null;
            for (int i = 0; i <= this.degree;i++ )
            {
                printStr += this.arrayFactor[i] + "*x^" + i;
            }
            return printStr.ToString();
        }

        public static Polinom operator +(Polinom polinom1,Polinom polinom2)
        {
            Polinom result = new Polinom(new float[Math.Max(polinom1.degree, polinom2.degree)]);
            if(polinom1.degree>=polinom2.degree)
            {
                for (int i = 0; i < polinom2.degree; i++)
                    result.arrayFactor[i] = polinom1.arrayFactor[i] + polinom2.arrayFactor[i];
                for (int j = polinom2.degree; j < polinom1.degree; j++)
                    result.arrayFactor[j] = polinom1.arrayFactor[j];
            }
            else
            {
                for (int i = 0; i < polinom1.degree; i++)
                    result.arrayFactor[i] = polinom1.arrayFactor[i] + polinom2.arrayFactor[i];
                for (int i = polinom1.degree + 1; i < polinom2.degree; i++)
                    result.arrayFactor[i] = polinom2.arrayFactor[i];
            }
            return result;
        }

        public static Polinom operator -(Polinom polinom1,Polinom polinom2)
        {
            Polinom result = new Polinom(new float[Math.Max(polinom1.degree, polinom2.degree)]);
            if (polinom1.degree >= polinom2.degree)
            {
                for (int i = 0; i < polinom2.degree; i++)
                    result.arrayFactor[i] = polinom1.arrayFactor[i] - polinom2.arrayFactor[i];
                for (int j = polinom2.degree; j < polinom1.degree; j++)
                    result.arrayFactor[j] = polinom1.arrayFactor[j];
            }
            else
            {
                for (int i = 0; i < polinom1.degree; i++)
                    result.arrayFactor[i] = polinom1.arrayFactor[i] - polinom2.arrayFactor[i];
                for (int i = polinom1.degree + 1; i < polinom2.degree; i++)
                    result.arrayFactor[i] =- polinom2.arrayFactor[i];
            }
            return result;
        }

        public static Polinom operator *(Polinom polinom1,Polinom polinom2)
        {
            Polinom result = new Polinom(new float[polinom1.degree+polinom2.degree-1]);
            for (int i = 0; i < polinom1.degree; i++)
                for (int j = 0; j < polinom2.degree; j++)
                    result.arrayFactor[i+j] += polinom1.arrayFactor[i] * polinom2.arrayFactor[j];
            return result;
        }

        public static Polinom operator / (Polinom polinom1,Polinom polinom2)
        {
            Polinom result;
            float[] dividend = polinom1.arrayFactor;
            if (polinom1.degree >= polinom2.degree)
            {
                if (polinom1.arrayFactor.Last() == 0|| polinom2.arrayFactor.Last()==0) throw new ArithmeticException("Invalid data of polinom");
                result = new Polinom(new float[polinom1.degree - polinom2.degree + 1]);
                for (int i = 0; i < result.degree; i++)
                {
                    float tempFactor = dividend[dividend.Length - i - 1] / polinom2.arrayFactor.Last();
                    result.arrayFactor[result.degree - i - 1] = tempFactor;
                    for (int j = 0; j < polinom2.degree; j++)
                    {
                        dividend[dividend.Length - i - j - 1] -= tempFactor * polinom2.arrayFactor[polinom2.degree - j - 1];
                    }
                }
            }
            else result = null;
            return result;
        }
    }
}
