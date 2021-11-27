using Common.Communication.Responses.Enums;
using System;

namespace Common.Communication.Responses
{
    class PingResponse : Response
    {
        public override ResponseType Type => ResponseType.PING;

        public void Process(Action action)
        {
            action.Invoke();
        }
    }
}
