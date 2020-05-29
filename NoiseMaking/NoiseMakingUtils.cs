using Flee.PublicTypes;
using System;

namespace Zynzezizer_cs
{
    struct MixInfo
    {
        public Func<float, float> function;
        public float mix;
        public int semi;
        public int fine;
    }

    class NoiseMakingUtils
    {
        private Random random;
        static float oneSemitone = (float)Math.Pow(2, 1 / 12f);

        public enum WaveForms
        {
            Sine, Sawtooth, Square, Triangle, Noise, Custom
        }

        public NoiseMakingUtils()
        {
            random = new Random();
        }

        public Func<float, float> getFunctionFromString(string formula)
        {
            ExpressionContext context = new ExpressionContext();
            context.Imports.AddType(typeof(Math));
            context.Variables.Add("x", (double)0);
            IGenericExpression<double> eGeneric = context.CompileGeneric<double>(formula);

            Func<float, float> result =
                (float x) =>
                {
                    context.Variables["x"] = (double)x;
                    return (float)(eGeneric.Evaluate());
                };
            return result;
        }

        public Func<float, float> getAdditiveMixedFunction(MixInfo[] mixInfo)
        {
            Func<MixInfo, float, float> mixInfoToFunction =
            (MixInfo mix, float x) =>
            {
                float power = mix.semi + (mix.fine / 100f);
                return mix.function(x * (float)Math.Pow(oneSemitone, power)) * mix.mix;
            };

            Func<float, float> result = 
            (float x) => 
            {
                float toReturn = 0;
                float actualLength = 0;
                for( int i = 0; i < mixInfo.Length; ++i)
                {
                    if (mixInfo[i].mix != 0)
                    {
                        toReturn += mixInfoToFunction(mixInfo[i], x);
                        actualLength += mixInfo[i].mix;
                    }
                }
                return toReturn / actualLength;
            };
            return result;
        }

        public Func<float, float> getFunctionByType(WaveForms type)
        {
            switch (type)
            {
                case WaveForms.Sine:
                    return x => (float)Math.Sin(x * 2 * Math.PI);
                case WaveForms.Sawtooth:
                    return x => (float)(Math.Atan(Math.Tan(x * Math.PI)) * 2 / Math.PI);
                case WaveForms.Square:
                    return x => Math.Sin(x * 2 * Math.PI) > 0 ? 1.0f : -1.0f;
                case WaveForms.Triangle:
                    return x => (float)(Math.Asin(Math.Sin(x * 2 * Math.PI)) * (2.0 / Math.PI));
                case WaveForms.Noise:
                    return x => (float)random.NextDouble() * 2 - 1;
                default:
                    return x => 0;
            }
        }

        public Func<float, float> getFunctionByName(string functionName)
        {
            switch (functionName)
            {
                case "Sine":
                    return x => (float)Math.Sin(x * 2 * Math.PI);
                case "Sawtooth":
                    return x => (float)(Math.Atan(Math.Tan(x * Math.PI)) * 2 / Math.PI);
                case "Square":
                    return x => Math.Sin(x * 2 * Math.PI) > 0 ? 1.0f : -1.0f;
                case "Triangle":
                    return x => (float)(Math.Asin(Math.Sin(x * 2 * Math.PI)) * (2.0 / Math.PI));
                case "Noise":
                    return x => (float)random.NextDouble() * 2 - 1;
                default:
                    return x => 0;
            }
        }

    }
}
