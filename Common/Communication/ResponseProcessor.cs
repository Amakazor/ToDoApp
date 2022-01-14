using Common.Communication.Responses.Enums;
using Common.Communication.Responses;
using Common.Serialization;
using System;
using Common.Communication.Responses.ResponseEvents;

namespace Common.Communication
{
    public class ResponseProcessor
    {
        public event EventHandler<PingResponsetEventArgs> RespondedPing;
        public event EventHandler<NullResponseEventArgs> RespondedNull;
        public event EventHandler<LoginResponseEventArgs> RespondedLogin;
        public event EventHandler<TasklistGetResponseEventArgs> RespondedTasklistGet;
        public event EventHandler<ErrorResponseEventArgs> RespondedError;
        public event EventHandler<TicketGetAllResponseEventArgs> RespondedTicketsGetAll;
        public event EventHandler<UserGetAllResponseEventArgs> RespondedUsersGetAll;


        public void Process(string responseData)
        {
            FireEvent(Serializer.DeserializeObject<Response>(responseData).Type switch
            {
                ResponseType.PING => Serializer.DeserializeObject<PingResponse>(responseData),
                ResponseType.NULL => Serializer.DeserializeObject<NullResponse>(responseData),
                ResponseType.LOGIN => Serializer.DeserializeObject<LoginResponse>(responseData),
                ResponseType.TASKLIST_GET => Serializer.DeserializeObject<TasklistGetResponse>(responseData),
                ResponseType.ERROR => Serializer.DeserializeObject<ErrorResponse>(responseData),
                ResponseType.TICKET_GET_ALL => Serializer.DeserializeObject<TicketGetAllResponse>(responseData),
                ResponseType.USER_GET_ALL => Serializer.DeserializeObject<UserGetAllResponse>(responseData),
                _ => throw new NotImplementedException(),
            });
        }

        private void FireEvent(Response response)
        {
            switch (response.Type)
            {
                case ResponseType.PING:
                    RespondedPing(this, (PingResponsetEventArgs)response.EventArgs);
                    break;
                case ResponseType.NULL:
                    RespondedNull(this, (NullResponseEventArgs)response.EventArgs);
                    break;
                case ResponseType.LOGIN:
                    RespondedLogin(this, (LoginResponseEventArgs)response.EventArgs);
                    break;
                case ResponseType.TASKLIST_GET:
                    RespondedTasklistGet(this, (TasklistGetResponseEventArgs)response.EventArgs);
                    break;
                case ResponseType.ERROR:
                    RespondedError(this, (ErrorResponseEventArgs)response.EventArgs);
                    break;
                case ResponseType.TICKET_GET_ALL:
                    RespondedTicketsGetAll(this, (TicketGetAllResponseEventArgs)response.EventArgs);
                    break;
                case ResponseType.USER_GET_ALL:
                    RespondedUsersGetAll(this, (UserGetAllResponseEventArgs)response.EventArgs);
                    break;
            }
        }
    }
}
