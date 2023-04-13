using Microsoft.ML.OnnxRuntime.Tensors;
using System;

namespace MummyNation_Team0113.Models
{
    public class APIData
    {
        // change data types 
        public float squarenorthsouth { get; set; }
        public float depth { get; set; }
        public float southtohead { get; set; }
        public long squareeastwest { get; set; }
        public float westtohead { get; set; }
        public float length { get; set; }
        public float westtofeet { get; set; }
        public float southtofeet { get; set; }
        public float textiles { get; set; }
        public float negative_southtohead { get; set; }
        public float negative_southtofeet { get; set; }
        public float negative_westtohead { get; set; }
        public float negative_westtofeet { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
            squarenorthsouth, depth, southtohead, squareeastwest,
            westtohead, length, westtofeet, southtofeet, textiles,
            negative_southtohead, negative_southtofeet, negative_westtohead,
            negative_westtofeet
            };
            int[] dimensions = new int[] { 1, 13};
            return new DenseTensor<float>(data, dimensions);
        }
    }

}
