using System;
using System.Collections.Generic;
using System.Text;
using TestPictureDemo.Database.SQLiteSettings.DbEntities;

namespace TestPictureDemo.Database.SQLiteSettings.DbServices.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<PrincipalPost> TDPrincipalPost { get; }
    }
}
