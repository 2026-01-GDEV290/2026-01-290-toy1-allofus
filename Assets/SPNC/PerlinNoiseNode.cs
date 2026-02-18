using Unity.VisualScripting;
using UnityEngine;

namespace SPNC
{
    [UnitTitle("Perlin Noise Node"), UnitCategory("SPNC")]
    public class PerlinNoiseNode : Unit
    {

        [DoNotSerialize, PortLabelHidden]
        public ControlInput inputTrigger;

        [DoNotSerialize, PortLabelHidden]
        public ControlOutput exit;

        [DoNotSerialize]
        public ValueInput x;
        [DoNotSerialize]
        public ValueInput y;

        [DoNotSerialize, PortLabelHidden]
        public ValueOutput c;


        protected override void Definition()
        {
            exit = ControlOutput("exit");


            x = ValueInput<float>("x", 0);
            y = ValueInput<float>("y", 0);

            bool t = false;
            float o = 0;

            c = ValueOutput<float>("c", (flow) => { return t? o: GetValue(flow); });
            inputTrigger = ControlInput("inputTrigger", (flow) =>
            {
                o = GetValue(flow);
                t = true;
                return exit;
            });
            Succession(inputTrigger, exit);
            Assignment(inputTrigger, c);
        }
        float GetValue(Flow flow)
        {
            float xv = flow.GetValue<float>(x);
            float yv = flow.GetValue<float>(y);
            return Mathf.PerlinNoise(xv, yv);
        }



    }
}