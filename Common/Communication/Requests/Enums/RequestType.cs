namespace Common.Communication.Requests.Enums
{
    public enum RequestType
    {
        PING,

        USER_LOGIN,
        USER_REGISTER,

        TASKLIST_GET,
        TASKLIST_ADD,
        TASKLIST_DELETE,
        TASKLIST_UPDATE,
        TASKLIST_MEMBER_ADD,
        TASKLIST_MEMBER_REMOVE,
        TASKLIST_OWNERSHIP_GIVE,

        TASK_ADD,
        TASK_DELETE,
        TASK_UPDATE,

        TASKSTATUS_ADD,
        TASKSTATUS_DELETE,
        TASKSTATUS_UPDATE,

        TICKED_ADD,
        USER_TICKET_GETALL,

        HELPDESK_TICKET_GETALL,
        HELPDESK_TICKET_UPDATE,

        ADMIN_USER_GETALL,
        ADMIN_USER_ACTIVATE,
        ADMIN_USER_DELETE,
    }
}
