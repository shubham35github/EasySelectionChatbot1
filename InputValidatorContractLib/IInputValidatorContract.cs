using System;
using System.Collections.Generic;
using System.Text;

namespace InputValidatorContractLib
{
    public interface IInputValidatorContract
    {
        bool Validate(string Input);
    }
}
