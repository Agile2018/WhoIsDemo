using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoIsDemo.model
{
    public class ParamsIdentify
    {
        public int A_MaxEyeDist { get; set; }
        public int A_MinEyeDist { get; set; }        
        public int A_IdentificationSpeed { get; set; }
        public int A_FaceDetectionForced { get; set; }

        public int A_SimilarityThreshold { get; set; }
        public int A_FaceDetectThreshold { get; set; }
        public int A_BestMatchedCandidates { get; set; }

    }
}
