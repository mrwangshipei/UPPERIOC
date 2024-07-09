using System;
using System.Collections.Generic;
using System.Text;

namespace UPPERIOC2._0.UPPER.AutoUpdate.Interfaces
{
    public interface UpdateProcess
    {
        bool CheckUpdate();
        bool UpdateFail();
        void NeedNotFail();
		bool Update();

        void FinishUpdate();
    }
}
