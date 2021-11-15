using System;
using System.Collections.Generic;
using System.Text;
using TestPictureDemo.Database.SQLiteSettings.DbEntities;
using TestPictureDemo.Database.SQLiteSettings.DbServices.Abstract;

namespace TestPictureDemo.Database.SQLiteSettings.DbServices
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {

        }

        public IRepository<PrincipalPost> TDPrincipalPost => new Repository<PrincipalPost>();
    }
}
