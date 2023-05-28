using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPowerStruct
{
    public struct RPower
    {
        double _base;
        public double Base
        {
            get => _base;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Значение должно быть положительным");
                _base = value;
            }
        }
        public double Exponent { get; set; }
        public double Value
        {
            get => Math.Pow(Base,Exponent);
        }
        public RPower(double _base, double exponent) : this()
        {
            Base = _base;
            Exponent = exponent;
        }
        public override string ToString() => $"{Base}E{Exponent}\"";
        public override bool Equals(object obj)
        {
            if (obj is RPower)
                return Value == ((RPower)obj).Value;
            throw new ArgumentException("Действительной степенью");
        }
        public override int GetHashCode() => Value.GetHashCode();
        public static bool operator ==(RPower x, RPower y) => x.Equals(y);
        public static bool operator !=(RPower x, RPower y) => !x.Equals(y);
        public static RPower operator *(RPower x, RPower y)
        {
            if (x.Base != y.Base)
                throw new ArgumentException("Для операции умножения основания должны быть равны!");
            var result = new RPower(x.Base, x.Exponent + y.Exponent);
            return result;
        }
        public static RPower operator /(RPower x, RPower y)
        {
            if (x.Base != y.Base)
                throw new ArgumentException("Для операции деления основания должны быть равны!");
            var result = new RPower(x.Base, x.Exponent - y.Exponent);
            return result;
        }
    }
}
