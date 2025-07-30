using System;

namespace SotongStudio.VContainer
{
    public class RegisterAsAttribute : Attribute, IRegisterAs
    {
        public RegisterAsAttribute(params Type[] registerTypes)
        {
            RegisterTypes = registerTypes;
        }

        public Type[] RegisterTypes { set; get; }

    }

    public interface IRegisterAs
    {
        public Type[] RegisterTypes { set; get; }
    }
}
