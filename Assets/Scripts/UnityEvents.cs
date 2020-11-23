using System;

namespace UnityEngine.Events
{
    [Serializable] public class SetString : UnityEvent<string> {}
    [Serializable] public class SetFloat : UnityEvent<float> {}
    [Serializable] public class SetSprite : UnityEvent<Sprite> {}
}
