
namespace HomeRadar.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// DatabaseAccess is for defining what state the app 
    /// could hit a local sql database at.
    /// </summary>
    public enum DatabaseAccess
    {
        None,  // 0
        Found,  // 1
        Remote_Access_Allowed,  // 2
        Remote_Access_Denied,  // 3
        No_Password,  // 4
        Password_Cracked
    }


    /// <summary>
    /// Report utils class.
    /// </summary>
    class ReportUtils
    {

    }
}
