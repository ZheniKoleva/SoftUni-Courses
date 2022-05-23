namespace _07.MilitaryElite.Models
{   
    using Interfaces;
    using Enumerators;

    public class Mission : IMission
    {
        public Mission(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }        

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
            => this.State = State.Finished;

        public override string ToString()
            => $"Code Name: {this.CodeName} State: {this.State}";      
      
    }
}
