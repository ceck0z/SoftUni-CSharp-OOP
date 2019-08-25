namespace P08_MilitaryElite.Models
{
    using System;
    using P08_MilitaryElite.Contracts;
    using P08_MilitaryElite.Enumerations;
    using P08_MilitaryElite.Exceptions;

    public class Mission : IMission
    {
        public Mission(string codename, string state)
        {
            this.CodeName = codename;

            ParseState(state); 
        }
               
        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if(this.State == State.Finished)
            {
                throw new InvalidMissionCompletionException();
            }

            this.State = State.Finished;
        }

        private void ParseState(string stateStr)
        {
            State state;

            bool parse = Enum.TryParse<State>(stateStr,out state);

            if (!parse)
            {
                throw new InvalidStateException();
            }

            this.State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
