using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class StateProgram
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            
            AcmaState acmaState = new AcmaState();
            acmaState.Action(context);

            DurdurState durdurState = new DurdurState();
            durdurState.Action(context);

            KapatmaState kapatmaState = new KapatmaState();
            kapatmaState.Action(context);


            Console.ReadLine();
        }
    }

    interface IState
    {
        void Action(Context context);
    }

    class DurdurState : IState
    {
        public void Action(Context context)
        {
            Console.WriteLine("State : Televizyon Duraklatıldı");
        }
    }

    class KapatmaState : IState
    {
        public void Action(Context context)
        {
            Console.WriteLine("State : Televizyon Kapatıldı");
        }
    }

    class AcmaState : IState
    {
        public void Action(Context context)
        {
            Console.WriteLine("State : Televizyon Açıldı");
        }
    }

    class Context
    {
        private IState _state;

        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
}
