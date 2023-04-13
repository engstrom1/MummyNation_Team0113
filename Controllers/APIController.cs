using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime.Tensors;
using Microsoft.ML.OnnxRuntime;
using System.Collections.Generic;
using System.Linq;
using MummyNation_Team0113.Models;

namespace MummyNation_Team0113.Controllers
{
        [ApiController]
        [Route("/score")]
        public class APIController : ControllerBase
        {
            private InferenceSession _session;

            public APIController(InferenceSession session)
            {
                _session = session;
            }

            [HttpPost]
            public ActionResult Score(APIData data)
            {
                var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", data.AsTensor())
            });
                Tensor<string> score = result.First().AsTensor<string>();
                var prediction = new Prediction { PredictedValue = score.First()};
                result.Dispose();
                return new JsonResult(prediction);
            }

        public class Prediction
        {
            public string PredictedValue { get; set; }
        }
    }
    }
