using System;
using Prism.Events;

namespace Xamalist
{
    // 「登録完了イベントだよ」っていう目印のために定義する必要のあったクラス
    public class RegisteredAppDataEvent : PubSubEvent
    {
        public RegisteredAppDataEvent()
        {
        }
    }
}
