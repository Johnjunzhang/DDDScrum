using System;

namespace DDDNotification
{
    public class FakeMessageSender
    {
        public static string Message { get; private set; }

        public static void Send(String backLogItemName, String sprintName)
        {
            Message = string.Format("backLogItem:[{0}] has been committed to sprint:[{1}]", backLogItemName, sprintName);
        }
    }
}
