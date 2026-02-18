using Unity.VisualScripting;

namespace SPNC
{
    [UnitTitle("Add Node"), UnitCategory("SPNC")]
    public class AddNode : Unit
    {
        [DoNotSerialize, PortLabelHidden]
        public ControlInput inputTrigger;

        [DoNotSerialize, PortLabelHidden]
        public ControlOutput exit;

        [DoNotSerialize]
        public ValueInput a;
        [DoNotSerialize]
        public ValueInput b;

        [DoNotSerialize, PortLabelHidden]
        public ValueOutput c;


        protected override void Definition()
        {
            exit = ControlOutput("exit");


            a = ValueInput<int>("a", 0);
            b = ValueInput<int>("b", 1);

            bool t = false;
            int o = 0;

            c = ValueOutput<int>("c", (flow) => { return t? o: flow.GetValue<int>(a) + flow.GetValue<int>(b); });
            inputTrigger = ControlInput("inputTrigger", (flow) =>
            {
                o = flow.GetValue<int>(a) + flow.GetValue<int>(b);
                t = true;
                return exit;
            });

            Succession(inputTrigger, exit);
            Assignment(inputTrigger, c);
        }



    }
}