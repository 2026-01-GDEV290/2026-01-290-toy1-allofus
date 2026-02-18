using Unity.VisualScripting;

namespace SPNC
{
    [UnitTitle("Do Nothing Node"), UnitCategory("SPNC")]
    public class DoNothingNode : Unit
    {

        [DoNotSerialize, PortLabelHidden]
        public ControlInput inputTrigger;

        [DoNotSerialize, PortLabelHidden]
        public ControlOutput exit;

        protected override void Definition()
        {
            exit = ControlOutput("exit");
            inputTrigger = ControlInput("inputTrigger", (flow) =>
            {
                // Run something from C# files
                return exit;
            });

            Succession(inputTrigger, exit);
        }



    }
}