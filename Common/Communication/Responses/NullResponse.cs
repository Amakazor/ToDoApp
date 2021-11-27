using Common.Communication.Responses.Enums;
using System;

namespace Common.Communication.Responses
{
    class NullResponse : Response
    {
        public override ResponseType Type => ResponseType.NULL;

        public void Process(Action action)
        {
            action.Invoke();
        }
    }
}
