using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolinomClass
{
    public class Polinom:IEquatable<Polinom>
    {
        private double[] factor;

        public Polinom(params double[] arrayFactor)
        {
            if (arrayFactor == null) throw new ArgumentNullException("Factor is null");
            factor = new double[arrayFactor.Length];
            Array.Copy(arrayFactor, factor,arrayFactor.Length);
        }

        public Polinom(int degree)
        {
            factor = new double[degree];
        }        
        
        public double this[int degree]
        {
            get
            {
                if (degree < 0 || degree > Power - 1) throw new InvalidOperationException("Invalid operation");
                return factor[degree];
            }
            private set
            {
                if (degree < 0 || degree > Power - 1) throw new InvalidOperationException("Invalid operation");
                factor[degree] = value;
            }
        }

        public int Power
        {
            get
            {
                return factor.Length;
            }
        }

        public static Polinom operator +(Polinom polinom1,Polinom polinom2)
        {
            if (Object.Equals(polinom1,null) || Object.Equals(polinom2,null)) throw new ArgumentNullException("Can not sum null polinoms");
            Polinom result;
            result = polinom1.Power > polinom2.Power ? new Polinom(polinom1.Power) : new Polinom(polinom2.Power);
           
            if(polinom1.Power>=polinom2.Power)
            {
                for (int i = 0; i < polinom2.Power; i++)
                    result[i] = polinom1[i] + polinom2[i];
                for (int j = polinom2.Power; j < polinom1.Power; j++)
                    result[j] = polinom1[j];
            }
            else
            {
                for (int i = 0; i < polinom1.Power; i++)
                    result[i] = polinom1[i] + polinom2[i];
                for (int i = polinom1.Power + 1; i < polinom2.Power; i++)
                    result[i] = polinom2[i];
            }
            return result;
        }

        public static Polinom operator-(Polinom polinom)
        {
            if(Object.Equals(polinom,null)) throw new ArgumentNullException("Can not sub null polinom");
            Polinom tempPolinom = new Polinom(polinom.Power);
            for (int i = 0; i < polinom.Power; i++)
                tempPolinom[i] = -polinom[i];
            return tempPolinom;
        }
        public static Polinom operator -(Polinom polinom1,Polinom polinom2)
        {
            if (Object.Equals(polinom1, null) || Object.Equals(polinom2, null)) throw new ArgumentNullException("Can not sub null polinoms");
            Polinom temp = -polinom2;
            return polinom1 + temp;
        }

        public static Polinom operator *(Polinom polinom1,Polinom polinom2)
        {
            if (Object.Equals(polinom1,null) || Object.Equals(polinom2,null)) throw new ArgumentNullException("Can not mul null polinoms");
            Polinom result = new Polinom(polinom1.Power + polinom2.Power - 1);
            for (int i = 0; i < polinom1.Power; i++)
                for (int j = 0; j < polinom2.Power; j++)
                    result[i+j] += polinom1[i] * polinom2[j];
            return result;
        }

        public static Polinom operator / (Polinom polinom1,Polinom polinom2)
        {
            if (Object.Equals(polinom1, null) || Object.Equals(polinom2, null)) throw new ArgumentNullException("Can not sum null polinom");
            for(int i=0;i<polinom2.Power;i++)
            {
                if (polinom2[i] == 0) throw new DivideByZeroException();
            }
            Polinom result;
            double[] dividend = polinom1.factor;
            if (polinom1.Power >= polinom2.Power)
            {
                if (polinom1.factor.Last() == 0|| polinom2.factor.Last()==0) throw new ArithmeticException("Invalid data of polinom");
                result = new Polinom(polinom1.Power - polinom2.Power + 1);
                for (int i = 0; i < result.Power; i++)
                {
                    double tempFactor = dividend[dividend.Length - i - 1] / polinom2.factor.Last();
                    result[result.Power - i - 1] = tempFactor;
                    for (int j = 0; j < polinom2.Power; j++)
                    {
                        dividend[dividend.Length - i - j - 1] -= tempFactor * polinom2[polinom2.Power - j - 1];
                    }
                }
            }
            else result = null;
            return result;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Polinom))
                return false;

            return Equals((Polinom)obj);
        }
        public bool Equals(Polinom polinom)
        {
            if (Object.Equals(polinom,null)) throw new ArgumentNullException("Can not equals null polinom");
            if (Power == polinom.Power)
            {
                for (int i = 0; i <Power; i++)
                    if (this[i] != polinom[i]) return false;
                return true;
            }
            return false;
        }

        public static bool operator ==(Polinom polinom1, Polinom polinom2)
        {
            if (Object.Equals(polinom1, null) || Object.Equals(polinom2, null)) throw new ArgumentNullException("Can not equals null polinoms");
            return polinom1.Equals(polinom2);
        }
        public static bool operator !=(Polinom polinom1, Polinom polinom2)
        {
            return !polinom1.Equals(polinom2);
        }
        public override int GetHashCode()
        {
            int num=0;
            if(factor==null) return base.GetHashCode();
            for(int i=0;i<Power;i++)
                num=num*33+factor[i].GetHashCode();
            return num;
        }
        public override string ToString()
        {
            string polinomStr=this.factor.Last()+"*x^"+(this.Power-1);
            for(int i=this.Power-2;i>=0;i--)
                polinomStr+="+"+this[i]+"*x^"+i;
            return polinomStr;
        }
      
        

   
    }
}
