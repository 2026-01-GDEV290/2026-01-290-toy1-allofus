using Unity.VisualScripting;

namespace SPNC
{
    [UnitTitle("For Loop Node"), UnitCategory("SPNC")]
    public class ForLoopNode : Unit
    {

        [DoNotSerialize, PortLabelHidden]
        public ControlInput inputTrigger;

        [DoNotSerialize]
        public ControlOutput body;
        [DoNotSerialize]
        public ControlOutput exit;

        [DoNotSerialize] 
        public ValueInput first;
        [DoNotSerialize]
        public ValueInput last;
        [DoNotSerialize]
        public ValueInput step;

        [DoNotSerialize]
        public ValueOutput index;


        protected override void Definition()
        {
            exit = ControlOutput("exit");
            body = ControlOutput("body");


            first = ValueInput<int>("first", 0);
            last = ValueInput<int>("last", 10);
            step = ValueInput<int>("step", 1);

            int i = 0;

            index = ValueOutput<int>("index", (flow) => { return i; });

            inputTrigger = ControlInput("inputTrigger", (flow) =>
            {
                int f = flow.GetValue<int>(first);
                int l = flow.GetValue<int>(last);
                int s = flow.GetValue<int>(step);
                //for (i = flow.GetValue<int>(first); i < flow.GetValue<int>(last); i += flow.GetValue<int>(step))
                //for (i = f; i < l; i += flow.GetValue<int>(step))
                for (i = f; i < l; i +=s)
                {
                    flow.Invoke(body);
                }
                return exit;
            });

            Succession(inputTrigger, body);
            Succession(inputTrigger, exit);
            Assignment(inputTrigger, index);
        }

    }
}