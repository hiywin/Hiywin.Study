using IoC.AspNetCore.IDAL;
using System;

namespace IoC.AspNetCore.IBLL
{
    public interface IStudentService
    {
        void Study();
        void PlayAbstractPhone(AbstractPhone phone);
    }
}
