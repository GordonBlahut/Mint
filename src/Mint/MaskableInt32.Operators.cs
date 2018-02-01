namespace Mint
{
    public partial struct MaskableInt32
    {
        public static implicit operator MaskableInt32(int source)
        {
            var maskedInt = new MaskableInt32 { Val = source };
            return maskedInt;
        }

        public static implicit operator int(MaskableInt32 source)
        {
            return source.Val;
        }

        public static implicit operator MaskableInt32? (int? source)
        {
            if (source.HasValue)
            {
                return new MaskableInt32 { Val = source.Value };
            }

            return null;
        }

        public static implicit operator string(MaskableInt32 source)
        {
            return source.GetMaskedValue();
        }

        public static bool operator ==(MaskableInt32 operand1, MaskableInt32 operand2)
        {
            return operand1.Val == operand2.Val;
        }

        public static bool operator ==(MaskableInt32 operand1, int operand2)
        {
            return operand1.Val == operand2;
        }

        public static bool operator ==(int operand1, MaskableInt32 operand2)
        {
            return operand1 == operand2.Val;
        }

        public static bool operator !=(MaskableInt32 operand1, MaskableInt32 operand2)
        {
            return !(operand1 == operand2);
        }

        public static bool operator !=(MaskableInt32 operand1, int operand2)
        {
            return !(operand1 == operand2);
        }

        public static bool operator !=(int operand1, MaskableInt32 operand2)
        {
            return !(operand1 == operand2);
        }

        public static bool operator >(MaskableInt32 operand1, MaskableInt32 operand2)
        {
            return operand1.Val > operand2.Val;
        }

		public static bool operator >(MaskableInt32 operand1, int operand2)
        {
            return operand1.Val > operand2;
        }

        public static bool operator >(int operand1, MaskableInt32 operand2)
        {
            return operand1 > operand2.Val;
        }

        public static bool operator >=(MaskableInt32 operand1, MaskableInt32 operand2)
        {
            return operand1.Val >= operand2.Val;
        }

        public static bool operator >=(MaskableInt32 operand1, int operand2)
        {
            return operand1.Val >= operand2;
        }

        public static bool operator >=(int operand1, MaskableInt32 operand2)
        {
            return operand1 >= operand2.Val;
        }

        public static bool operator <(MaskableInt32 operand1, MaskableInt32 operand2)
        {
            return operand1.Val < operand2.Val;
        }

        public static bool operator <(MaskableInt32 operand1, int operand2)
        {
            return operand1.Val < operand2;
        }

        public static bool operator <(int operand1, MaskableInt32 operand2)
        {
            return operand1 < operand2.Val;
        }

        public static bool operator <=(MaskableInt32 operand1, MaskableInt32 operand2)
        {
            return operand1.Val <= operand2.Val;
        }

        public static bool operator <=(MaskableInt32 operand1, int operand2)
        {
            return operand1.Val <= operand2;
        }

        public static bool operator <=(int operand1, MaskableInt32 operand2)
        {
            return operand1 <= operand2.Val;
        }

        public static MaskableInt32 operator +(MaskableInt32 operand1, MaskableInt32 operand2)
        {
            MaskableInt32 maskableInt32 = operand1.Val + operand2.Val;
            return maskableInt32;
        }

        public static MaskableInt32 operator +(MaskableInt32 operand1, int operand2)
        {
            MaskableInt32 maskableInt32 = operand1.Val + operand2;
            return maskableInt32;
        }

        public static MaskableInt32 operator +(int operand1, MaskableInt32 operand2)
        {
            MaskableInt32 maskableInt32 = operand1 + operand2.Val;
            return maskableInt32;
        }

        public static MaskableInt32 operator -(MaskableInt32 operand1, MaskableInt32 operand2)
        {
            MaskableInt32 maskableInt32 = operand1.Val - operand2.Val;
            return maskableInt32;
        }

        public static MaskableInt32 operator -(MaskableInt32 operand1, int operand2)
        {
            MaskableInt32 maskableInt32 = operand1.Val - operand2;
            return maskableInt32;
        }

        public static MaskableInt32 operator -(int operand1, MaskableInt32 operand2)
        {
            MaskableInt32 maskableInt32 = operand1 - operand2.Val;
            return maskableInt32;
        }

        public static MaskableInt32 operator *(MaskableInt32 operand1, MaskableInt32 operand2)
        {
            MaskableInt32 maskableInt32 = operand1.Val * operand2.Val;
            return maskableInt32;
        }
        
        public static MaskableInt32 operator *(MaskableInt32 operand1, int operand2)
        {
            MaskableInt32 maskableInt32 = operand1.Val * operand2;
            return maskableInt32;
        }

        public static MaskableInt32 operator *(int operand1, MaskableInt32 operand2)
        {
            MaskableInt32 maskableInt32 = operand1 * operand2.Val;
            return maskableInt32;
        }
        
        public static MaskableInt32 operator /(MaskableInt32 operand1, MaskableInt32 operand2)
        {
            MaskableInt32 maskableInt32 = operand1.Val / operand2.Val;
            return maskableInt32;
        }
        
        public static MaskableInt32 operator /(MaskableInt32 operand1, int operand2)
        {
            MaskableInt32 maskableInt32 = operand1.Val / operand2;
            return maskableInt32;
        }

        public static MaskableInt32 operator /(int operand1, MaskableInt32 operand2)
        {
            MaskableInt32 maskableInt32 = operand1 / operand2.Val;
            return maskableInt32;
        }
        
        public static MaskableInt32 operator %(MaskableInt32 operand1, MaskableInt32 operand2)
        {
            MaskableInt32 maskableInt32 = operand1.Val % operand2.Val;
            return maskableInt32;
        }
		
        public static MaskableInt32 operator %(MaskableInt32 operand1, int operand2)
        {
            MaskableInt32 maskableInt32 = operand1.Val % operand2;
            return maskableInt32;
        }

        public static MaskableInt32 operator %(int operand1, MaskableInt32 operand2)
        {
            MaskableInt32 maskableInt32 = operand1 % operand2.Val;
            return maskableInt32;
        }
    }
}
